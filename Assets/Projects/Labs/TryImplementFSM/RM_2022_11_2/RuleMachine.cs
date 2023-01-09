using System;
namespace Labs.TryImplementFSM.RM_2022_11_2
{

	public abstract class RuleMachine<TEntryParam>
		where TEntryParam : class
	{
		protected abstract Action[] CreateRules();

		protected RuleMachine()
		{
			Rules = CreateRules();
		}

		protected TEntryParam CurEntryParam;
		Action[] Rules;
		public void Run(TEntryParam EntryParam)
		{
			CurEntryParam = EntryParam;
			foreach (var rule in Rules)
			{
				rule();
			}
		}
	}
}