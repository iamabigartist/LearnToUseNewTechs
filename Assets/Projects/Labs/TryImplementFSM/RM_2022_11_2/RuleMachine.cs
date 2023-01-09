using System;
namespace Labs.TryImplementFSM.RM_2022_11_2
{

	public abstract class RuleMachine<TEntryParam>
		where TEntryParam : class
	{
		public class Rule
		{
			public string Id;
			public Action ProcessData;
			public Rule(string Id, Action ProcessData)
			{
				this.Id = Id;
				this.ProcessData = ProcessData;
			}
		}

		protected abstract Rule[] CreateRules();

		public void Initialise()
		{
			Rules = CreateRules();
		}

		protected TEntryParam CurEntryParam;
		Rule[] Rules;
		public void Run(TEntryParam EntryParam)
		{
			CurEntryParam = EntryParam;
			foreach (var rule in Rules)
			{
				rule.ProcessData();
			}
		}
	}
}