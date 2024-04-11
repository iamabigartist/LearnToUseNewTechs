using System;
using System.Collections.Generic;
using static ProjectUtils.MiscUtils;
namespace Labs.TryImplementFSM.RM_2022_11_2
{
	public class State<TEnum>
	{
		public TEnum Current;
		public TEnum Next;
		public Dictionary<(TEnum Current, TEnum Next), Action> OnTransitStateActions;
		public State(TEnum Initial, Dictionary<(TEnum Current, TEnum Next), Action> OnTransitStateActions)
		{
			Current = Initial;
			this.OnTransitStateActions = OnTransitStateActions;
			Next = Current;
		}

		public bool TransitState(out (TEnum Current, TEnum Next) states)
		{
			states = (Current, Next);
			OnTransitStateActions.TryGetValue(states, out var action);
			CompareAndUpdate(ref Current, Next, (a, b) => a.Equals(b), out var changed);
			if (changed) { action!.Invoke(); }
			return changed;
		}
	}
}