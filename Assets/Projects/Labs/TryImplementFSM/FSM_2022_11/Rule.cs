namespace Labs.TryImplementFSM.FSM_2022_11
{
	public class Rule<TState>
	{
		public delegate TState NextStateDelegate();

		public string Id;
		public NextStateDelegate NextState;
		public Rule(string Id, NextStateDelegate NextState)
		{
			this.Id = Id;
			this.NextState = NextState;
		}
	}

}