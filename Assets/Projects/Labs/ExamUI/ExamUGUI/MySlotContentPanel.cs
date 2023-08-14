using UnityEngine;
using UnityEngine.UI;
namespace Labs.ExamUI.ExamUGUI
{
	public class MySlotContentPanel : MonoBehaviour
	{
		SlotPanel m_slot_panel;
		void Awake()
		{
			m_slot_panel = GetComponentInParent<SlotPanel>();
			m_slot_panel.OnCreate += () =>
			{
				var text_gui = GetComponentInChildren<Text>();
				text_gui.text = $"{m_slot_panel.transform.GetSiblingIndex()}";
			};
		}

		void Update() {}
	}
}