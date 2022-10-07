using UnityEngine;
using Utils;
using static Labs.TryImplementFSM.MyEventData.EventType;
using static Labs.TryImplementFSM.MyState;
namespace Labs.TryImplementFSM

{
	using MyFSM = StateTransition_2022_10<MyState, MyRuleKey, MyEventData>;
	public enum MyState { Walk, Run, Shoot }
	public abstract class MyEventData
	{
		public enum EventType { Hurt, Healed, Dead, Shocked }
		public EventType Type;
		protected MyEventData(EventType Type)
		{
			this.Type = Type;
		}
	}

	public class HurtEvent : MyEventData
	{
		public HurtEvent() : base(Hurt) {}
	}

	public class MyRuleKey : MyFSM.BaseRuleKey
	{
		public ValueFilter<TestFSM.ExpectType> ExpectType = new();
		public ValueFilter<MyEventData.EventType> EventType = new();
	}

	public class TestFSM : MonoBehaviour
	{
		public enum ExpectType { Perfect, NotBad, Nub }
		public float CurrentStateTimer;
		public ExpectType CurrentExpectType;

		MyFSM.Machine m_machine1;
		void Start()
		{
			m_machine1 = new(Shoot,
				Key => Key.ExpectType.Match(CurrentExpectType),
				(Key, EventData) => Key.EventType.Match(EventData.Type),
				Machine => new MyFSM.Rule[]
				{
					new("First Rule",
						new() { CurrentState = new(Run) },
						() => CurrentStateTimer > 2 ? Walk : Machine.cur_state),
					new("Second Rule",
						new() { CurrentState = new(Walk) },
						() => CurrentStateTimer > 2 ? Shoot : Machine.cur_state),
					new("Shoot End",
						new() { CurrentState = new(Shoot), SkipNoEvent = true, EventType = new(Hurt) },
						() => Run)
				}, Results => Results[0]);
			m_machine1.OnStateChange += (State, NewState, Rule) => Debug.Log($"from {State} to {NewState} according to {Rule.Id} ");
			m_machine1.OnStateChange += (_, _, _) => CurrentStateTimer = 0;
			m_machine1.UpdateState(new HurtEvent());
		}

		void Update()
		{
			CurrentStateTimer += Time.deltaTime;
			m_machine1.UpdateState();
		}
	}
}