using System.Collections.Generic;
namespace Labs.TryImplementFSM.RM_2022_11_2
{
	public class RuleMachine<TData, TParam> where TData : new()
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
		public RuleMachine()
		{
			MachineData = new();
			Rules = new();
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