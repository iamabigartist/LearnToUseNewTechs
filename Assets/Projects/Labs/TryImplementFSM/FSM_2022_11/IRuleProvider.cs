namespace Labs.TryImplementFSM.FSM_2022_11
{
	public interface IRuleProvider<TState>
	{
		Rule<TState>[] GetEffectiveRules();
	}
}