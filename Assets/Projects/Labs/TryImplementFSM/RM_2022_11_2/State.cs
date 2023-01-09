using System.Collections.Generic;
using static Utils.MiscUtils;
namespace Labs.TryImplementFSM.RM_2022_11_2
{
	public class State<TEnum, TAction>
	{
		public TEnum Current;
		public TEnum Next;
		public Dictionary<(TEnum Current, TEnum Next), TAction> OnTransitStateActions;
		public State(TEnum Initial, Dictionary<(TEnum Current, TEnum Next), TAction> OnTransitStateActions)
		{
			Current = Initial;
			this.OnTransitStateActions = OnTransitStateActions;
			Next = Current;
		}

		public bool TransitState(out (TEnum Current, TEnum Next) states, out TAction action)
		{
			states = (Current, Next);
			OnTransitStateActions.TryGetValue(states, out action);
			CompareAndUpdate(ref Current, Next, (a, b) => a.Equals(b), out var changed);
			return changed;
		}
	}
}