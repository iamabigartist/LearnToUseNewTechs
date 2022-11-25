using System.Collections.Generic;
using System.Linq;
namespace Labs.TryImplementFSM.RM_2022_11_2
{
	public class RuleMachine<TData, TRule>
		where TRule : RuleMachine<TData, TRule>.BaseRule
	{
		public delegate void ProcessDataDelegate(TData data);
		public abstract class BaseRule
		{
			public string Id;
			public ProcessDataDelegate ProcessData;
			protected BaseRule(string Id, ProcessDataDelegate ProcessData)
			{
				this.Id = Id;
				this.ProcessData = ProcessData;
			}
		}
		public TData Data;
		public List<TRule> Rules;
		public RuleMachine(TData Data, params TRule[] Rules)
		{
			this.Data = Data;
			this.Rules = Rules.ToList();
		}

		public void Update()
		{
			foreach (var rule in Rules)
			{
				rule.ProcessData(Data);
			}
		}


	}
}