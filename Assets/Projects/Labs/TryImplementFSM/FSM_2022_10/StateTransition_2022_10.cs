using System.Collections.Generic;
using System.Linq;
using Utils;
namespace Labs.TryImplementFSM.FSM_2022_10
{
	// 待实现，animator的trigger event调用建议在自己的模型中使用message pipeline进行实现, 因为这样机器入口更加一致。事件附带的信息，实际上是只存在于那一时刻，用完即刻删掉的信息，因此如果使用固定的变量位置保存，可能会造成不方便，因为每种事件都要在data中留地方，而不是写成函数接口。而反过来，写成函数接口就必然导致信息的不够灵活。

	/// <typeparam name="TState">Machine State</typeparam>
	/// <typeparam name="TRuleKey">Key used for filter the rules that the machine should check.</typeparam>
	/// <typeparam name="TEventData">The data within a event send to the machine.</typeparam>
	public class StateTransition_2022_10<TState, TRuleKey, TEventData>
		where TRuleKey : StateTransition_2022_10<TState, TRuleKey, TEventData>.BaseRuleKey
	{
		public delegate TState GenRuleResult();
		public delegate Rule[] RuleFactory(Machine Machine);
		public delegate bool DataMatch(TRuleKey Key);
		public delegate bool EventMatch(TRuleKey Key, TEventData EventData);

		public class BaseRuleKey
		{
			/// <summary>
			///     <para> Match only when there exist the event in a update, skip if no event</para>
			/// </summary>
			public bool SkipNoEvent = false;
			public ValueFilter<TState> CurrentState = new();
			public bool StateMatch(TState CurState) => CurrentState.Match(CurState);
		}

		public class Rule
		{
			public string Id;
			public TRuleKey Key;
			public GenRuleResult ResultMethod;
			public Rule(string Id, TRuleKey Key, GenRuleResult ResultMethod)
			{
				this.Id = Id;
				this.Key = Key;
				this.ResultMethod = ResultMethod;
			}
		}

		public class StateTransitionResult
		{
			public Rule Rule;
			public TState State;
			public StateTransitionResult(Rule Rule, TState State)
			{
				this.Rule = Rule;
				this.State = State;
			}
		}

		public class Machine
		{
			public delegate void StateChange(TState OldState, TState NewState, Rule TransitionRule);
			public delegate StateTransitionResult TransitionResultSelector(List<StateTransitionResult> Results);
			public event StateChange OnStateChange;
			DataMatch DataMatch;
			EventMatch EventMatch;
			TransitionResultSelector RulePrioritySelector;
			public TState cur_state;
			Dictionary<TRuleKey, List<Rule>> rules;

			public Machine(
				TState InitState, DataMatch DataMatch, EventMatch EventMatch,
				RuleFactory GenRules, TransitionResultSelector RulePrioritySelector)
			{
				cur_state = InitState;
				this.DataMatch = DataMatch;
				this.EventMatch = EventMatch;
				rules = GenRules(this).
					GroupBy(rule => rule.Key).
					ToDictionary(group => group.Key, group => group.
						Select(rule => rule).
						ToList());
				this.RulePrioritySelector = RulePrioritySelector;
			}

			void ExecuteRules(IEnumerable<TRuleKey> Keys, out List<StateTransitionResult> Results)
			{
				Results = new();
				foreach (var key in Keys)
				{
					foreach (var rule in rules[key])
					{
						var result_state = rule.ResultMethod();
						if (!result_state.Equals(cur_state)) { Results.Add(new(rule, result_state)); }
					}
				}
			}

			void ExecuteTransition(StateTransitionResult Result)
			{
				OnStateChange?.Invoke(cur_state, Result.State, Result.Rule);
				cur_state = Result.State;
			}

			bool UpdateState(TEventData EventData, bool EmptyEvent)
			{
				var matched_keys = rules.Keys.Where(key =>
					key.StateMatch(cur_state) &&
					DataMatch(key) &&
					(!key.SkipNoEvent || (!EmptyEvent && EventMatch(key, EventData))));
				ExecuteRules(matched_keys, out var results);
				if (results.Count == 0) { return false; }
				var selected_result = RulePrioritySelector(results);
				if (selected_result.State.Equals(cur_state)) { return false; }
				ExecuteTransition(selected_result);
				return true;
			}
			public bool UpdateState(TEventData EventData) => UpdateState(EventData, false);
			public bool UpdateState() => UpdateState(default, true);

		}
	}
}