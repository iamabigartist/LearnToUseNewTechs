using UnityEngine;
using UnityEngine.UI;
using static Labs.ExamUGUI.BackpackPanel.InputEvent;
namespace Labs.ExamUGUI
{
	public class BackpackPanel : MonoBehaviour
	{
		public enum InputEvent
		{
			Pick,
			Enter,
			Drop
		}
		public enum BackpackEvent
		{
			Pick,
			DragMove,
			Drop
		}

	#region Config

		public GameObject SlotContent;
		public GameObject IconContent;

	#endregion

	#region State

		SlotPanel pointer_over_slot_panel;
		SlotPanel dragging_slot_panel;
		bool input_enter;
		bool dragging;

	#endregion

	#region Data

		IconPanel icon_panel;

	#endregion

	#region Process

	#region Create

		void CreateSlotPanelGameObject(out GameObject SlotPanelGameObject, out SlotPanel CurSlotPanel)
		{
			var cur_slot_gobj = new GameObject($"SlotPanel {transform.childCount}");
			cur_slot_gobj.AddComponent<RectTransform>();
			cur_slot_gobj.AddComponent<CanvasRenderer>();
			var cur_image = cur_slot_gobj.AddComponent<Image>();
			var cur_pointer_messager = cur_slot_gobj.AddComponent<PointerMoveMessager>();
			var cur_slot_panel = cur_slot_gobj.AddComponent<SlotPanel>();
			cur_slot_gobj.transform.SetParent(transform, false);
			cur_image.color = Color.clear;
			cur_pointer_messager.PointerEnter += (panel_gobj, _) =>
			{
				pointer_over_slot_panel = panel_gobj.GetComponent<SlotPanel>();
				input_enter = true;
			};
			cur_pointer_messager.PointerExit += (panel_gobj, _) =>
			{
				pointer_over_slot_panel = null;
			};

			SlotPanelGameObject = cur_slot_gobj;
			CurSlotPanel = cur_slot_panel;
		}

		void CreateSlot()
		{
			CreateSlotPanelGameObject(out var slot_gobj, out var cur_slot_panel);
			var cur_slot_content = Instantiate(SlotContent, slot_gobj.transform);
			cur_slot_panel.Create();
		}

		void CreateIconPanelGameObject(out GameObject IconPanelGameObject)
		{
			var icon_gobj = new GameObject($"{gameObject.name} Icon");
			icon_gobj.AddComponent<RectTransform>();
			icon_panel = icon_gobj.AddComponent<IconPanel>();
			icon_gobj.transform.SetParent(GetComponentInParent<Canvas>().transform, false);
			var rect_transform = icon_gobj.transform as RectTransform;
			rect_transform.sizeDelta = new(80, 80);
			icon_panel.Create();
			IconPanelGameObject = icon_gobj;
		}
		void CreateIcon()
		{
			CreateIconPanelGameObject(out var icon_gobj);
			var icon_content = Instantiate(IconContent, icon_gobj.transform);
			icon_gobj.SetActive(false);
			icon_gobj.layer = LayerMask.GetMask("Ignore Raycast");
		}

	#endregion

	#region Icon

		void ActivateIcon()
		{
			icon_panel.OnPick(dragging_slot_panel);
			icon_panel.gameObject.SetActive(true);
			icon_panel.Show();
		}

		void UpdateIcon()
		{
			if (icon_panel != null) { icon_panel.IconUpdate(); }
		}

		void DeactivateIcon()
		{
			icon_panel.Hide();
			icon_panel.gameObject.SetActive(false);
			icon_panel.OnDrop();
		}

	#endregion

	#region BackpackEvent

		void GetInputEvent_OldInputSystem(out InputEvent? CurInputEvent)
		{
			if (Input.GetMouseButtonDown(0))
			{
				CurInputEvent = Pick;
			}
			else if (Input.GetMouseButtonUp(0))
			{
				CurInputEvent = Drop;
			}
			else if (input_enter)
			{
				CurInputEvent = Enter;
			}
			else { CurInputEvent = null; }
		}

		void InputToBackpackEvent(InputEvent? CurInputEvent, out BackpackEvent? CurBackpackEvent)
		{
			CurBackpackEvent = CurInputEvent switch
			{
				Pick when pointer_over_slot_panel != null && !dragging => BackpackEvent.Pick,
				Drop when dragging => BackpackEvent.Drop,
				Enter when dragging => BackpackEvent.DragMove,
				_ => null
			};
		}

		void ProcessBackpackEvent(BackpackEvent? CurBackpackEvent)
		{
			switch (CurBackpackEvent)
			{
				case BackpackEvent.Pick:
					ProcessPickEvent();
					break;
				case BackpackEvent.DragMove:
					break;
				case BackpackEvent.Drop:
					ProcessDropEvent();
					break;
			}
		}

		void ResetInputEventState()
		{
			input_enter = false;
		}

		void ProcessPickEvent()
		{
			dragging_slot_panel = pointer_over_slot_panel;
			dragging = true;
			ActivateIcon();
		}

		void ProcessDropEvent()
		{
			DeactivateIcon();
			dragging = false;
			if (pointer_over_slot_panel != null)
			{
				ExchangeSlot(dragging_slot_panel, pointer_over_slot_panel);
			}
		}

	#endregion

	#region Slot

		void ExchangeSlot(SlotPanel SlotA, SlotPanel SlotB)
		{
			var dragging_slot_index = SlotA.transform.GetSiblingIndex();
			var drop_over_slot_index = SlotB.transform.GetSiblingIndex();
			SlotA.transform.SetSiblingIndex(drop_over_slot_index);
			SlotB.transform.SetSiblingIndex(dragging_slot_index);
		}

	#endregion

	#endregion

	#region Entry

		void BackpackStart()
		{
			CreateIcon();
			for (int i = 0; i < 10; i++) { Test_AddSlot(); }
		}

		void BackpackUpdate()
		{
			UpdateIcon();
			GetInputEvent_OldInputSystem(out var input_event);
			InputToBackpackEvent(input_event, out var backpack_event);
			ProcessBackpackEvent(backpack_event);
			// Debug.Log($"Event: {backpack_event}, dragging: {dragging}\n" +
			// 	$"dragging: {dragging_slot_panel?.gameObject.name ?? "None"}, " +
			// 	$"pointer_over: {pointer_over_slot_panel?.gameObject.name ?? "None"}");
			ResetInputEventState();
		}

	#endregion

	#region UnityEnrty

		void Start()
		{
			BackpackStart();
		}

		void Update()
		{
			BackpackUpdate();
		}

	#endregion

	#region Test

		[ContextMenu("Test/AddSlot")]
		void Test_AddSlot()
		{
			CreateSlot();
		}

	#endregion
	}
}