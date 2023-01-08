using System;
using System.Collections.Generic;
namespace Labs.TryImplementFSM.RM_2022_11_2
{
	public class State<TEnum>
		where TEnum : Enum
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
			bool changed = !Next.Equals(Current);
			if (changed)
			{
				OnTransitStateActions.TryGetValue(states, out var on_transit_state);
				on_transit_state?.Invoke();
				Current = Next;
			}
			return changed;
		}
	}
}