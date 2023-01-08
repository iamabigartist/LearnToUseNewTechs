using System.Collections.Generic;
using System.Linq;
namespace Labs.TryImplementFSM.RM_2022_11_2
{

	public class RuleMachine<TData, TParam> where TData : new()
	{
		// 如果要做Data和Param的继承，那么就在下一层类中继续使用泛型，并且使用泛型约束来继承父类型

		public delegate void ProcessDataDelegate(TData Data, TParam Param);
		public class Rule
		{
			public string Id;
			public ProcessDataDelegate ProcessData;
			public Rule(string Id, ProcessDataDelegate ProcessData)
			{
				this.Id = Id;
				this.ProcessData = ProcessData;
			}
		}

		protected RuleMachine(TData MachineData, Rule[] Rules)
		{
			this.MachineData = MachineData;
			this.Rules = Rules.ToList();
		}

		public TData MachineData;
		public List<Rule> Rules;

		public void Run(TParam EntryParam)
		{
			foreach (var rule in Rules)
			{
				rule.ProcessData(MachineData, EntryParam);
			}
		}
	}
}