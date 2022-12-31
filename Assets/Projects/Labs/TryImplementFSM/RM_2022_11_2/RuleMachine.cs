using System.Collections.Generic;
using System.Linq;
namespace Labs.TryImplementFSM.RM_2022_11_2
{
	public class RuleMachine<TData, TParam>
	{
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
		public TData MachineData;
		public List<Rule> Rules;
		public RuleMachine(TData MachineData, params Rule[] Rules)
		{
			this.MachineData = MachineData;
			this.Rules = Rules.ToList();
		}

		public void Run(TParam EntryParam)
		{
			foreach (var rule in Rules)
			{
				rule.ProcessData(MachineData, EntryParam);
			}
		}
	}
}