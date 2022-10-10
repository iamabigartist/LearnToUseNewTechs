using UnityEngine.Events;
using UnityEngine.EventSystems;
public static class Util
{
	public static EventTrigger.Entry CreateEventTriggerEntry(EventTriggerType TriggerType, params UnityAction<BaseEventData>[] callbacks)
	{
		var entry = new EventTrigger.Entry
		{
			eventID = TriggerType
		};
		foreach (var action in callbacks)
		{
			entry.callback.AddListener(action);
		}
		return entry;
	}
}