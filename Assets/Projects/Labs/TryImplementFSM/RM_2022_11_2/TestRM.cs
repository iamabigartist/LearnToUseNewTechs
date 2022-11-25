using UnityEngine;
using static Labs.TryImplementFSM.RM_2022_11_2.MyRuleMachine;
namespace Labs.TryImplementFSM.RM_2022_11_2
{
	public class MyRuleMachine : RuleMachine<MyData, MyRule>
	{
		public class MyData {}
		public class MyRule : BaseRule
		{
			public MyRule(string Id, ProcessDataDelegate ProcessData) : base(Id, ProcessData) {}
		}
		public MyRuleMachine(MyData Data, params MyRule[] Rules) : base(Data, Rules) {}
	}

	public class TestRm : MonoBehaviour
	{
		MyRuleMachine machine;
		void Start()
		{
			machine = new(new(),
				new MyRule("First Rule", data =>
				{
					
				}),
				new MyRule("Second Rule", data => {}));
		}
	}
}