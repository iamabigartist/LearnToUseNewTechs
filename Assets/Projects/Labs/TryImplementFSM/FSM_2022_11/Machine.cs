using System;
using System.Collections.Generic;
namespace Labs.TryImplementFSM.FSM_2022_11
{
	public class Machine<TState, TRuleProvider>
		where TRuleProvider : IRuleProvider<TState>
	{
		public class TransitionResult
		{
			public Rule<TState> Rule;
			public TState State;
			public TransitionResult(Rule<TState> Rule, TState State)
			{
				this.Rule = Rule;
				this.State = State;
			}
		}
		public delegate TransitionResult SelectTransitionDelegate(List<TransitionResult> Results);
		public delegate void StateChangeDelegate(TState OldState, TState NewState, Rule<TState> TransitionRule);
		public event StateChangeDelegate StateChange;
		TState cur_state;
		TRuleProvider rule_provider;
		SelectTransitionDelegate select_transition;

		public Machine(
			TState InitState, TRuleProvider RuleProvider, SelectTransitionDelegate SelectTransition)
		{
			cur_state = InitState;
			select_transition = SelectTransition;
			rule_provider = RuleProvider;
		}
		void ExecuteRules(Rule<TState>[] EffectiveRules, out List<TransitionResult> Results)
		{
			Results = new();
			foreach (var rule in EffectiveRules)
			{
				var result_state = rule.NextState();
				if (!result_state.Equals(cur_state)) { Results.Add(new(rule, result_state)); }
			}
		}
		void ExecuteTransition(TransitionResult Result)
		{
			StateChange?.Invoke(cur_state, Result.State, Result.Rule);
			cur_state = Result.State;
		}
		bool UpdateState()
		{
			ExecuteRules(rule_provider.GetEffectiveRules(), out var results);
			if (results.Count == 0) { return false; }
			var selected_result = select_transition(results);
			if (selected_result.State.Equals(cur_state)) { return false; }
			ExecuteTransition(selected_result);
			return true;
		}

	}
}