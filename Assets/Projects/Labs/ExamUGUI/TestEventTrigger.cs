using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.EventTriggerType;
using static Labs.ExamUGUI.Util;
public class TestEventTrigger : MonoBehaviour
{
	void Start()
	{
		var event_trigger = GetComponent<EventTrigger>();
		var pointer_click_entry = CreateEventTriggerEntry(PointerEnter,
			BaseEventData =>
			{
				if (BaseEventData is PointerEventData data)
				{
					Debug.Log($"GetIt.{gameObject.name}");
				}
			});
		event_trigger.triggers.Add(pointer_click_entry);


	}
}