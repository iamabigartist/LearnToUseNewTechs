namespace Labs.TryImplementFSM.FSM_2022_10
{
	public class ChildFSMTest
	{
		public class ChildFSM<TEventData> : StateTransition_2022_10<MyState, ChildFSM<TEventData>.MyMyRuleKey, TEventData>
		{
			public class MyMyRuleKey : BaseRuleKey
			{
				
			}
		}
	}
}