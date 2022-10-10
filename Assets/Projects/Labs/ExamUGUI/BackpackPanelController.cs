using UnityEngine;
using UnityEngine.UI;
namespace Labs.ExamUGUI
{
	public class BackpackPanelController : MonoBehaviour
	{
	#region Asset

		GameObject SlotTemplate;

	#endregion

	#region Config

		public GameObject SlotContent;

	#endregion

	#region State

		public GameObject pointer_over_slot_panel;

	#endregion

	#region Process

		void CreateSlotPanelGameObject(out GameObject SlotPanelGameObject)
		{
			var cur_slot_panel = new GameObject($"SlotPanel {transform.childCount}");
			cur_slot_panel.AddComponent<RectTransform>();
			cur_slot_panel.AddComponent<CanvasRenderer>();
			var cur_image = cur_slot_panel.AddComponent<Image>();
			var cur_pointer_messager = cur_slot_panel.AddComponent<PointerMoveMessager>();
			var cur_slot_panel_controller = cur_slot_panel.AddComponent<SlotPanelController>();
			cur_slot_panel.transform.SetParent(transform, false);
			cur_image.color = Color.clear;
			cur_slot_panel_controller.OnCreateSlot();
			cur_pointer_messager.PointerEnter += (panel_gameobject, _) =>
			{
				Debug.Log($"Enter {panel_gameobject.name}");
				pointer_over_slot_panel = panel_gameobject;
			};
			cur_pointer_messager.PointerExit += (panel_gameobject, _) =>
			{
				Debug.Log($"Exit {panel_gameobject.name}");
				pointer_over_slot_panel = null;
			};
			SlotPanelGameObject = cur_slot_panel;
		}

		void CreateSlot()
		{
			CreateSlotPanelGameObject(out var cur_slot_panel);
			var cur_slot_content = Instantiate(SlotContent, cur_slot_panel.transform);
		}

	#endregion

	#region UnityEnrty

		void Awake() {}

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