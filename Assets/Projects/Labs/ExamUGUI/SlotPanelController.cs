using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace Labs.ExamUGUI
{
	public class SlotPanelController:MonoBehaviour
	{
		PointerMoveMessager pointer_move_messager;
		public void OnCreateSlot()
		{
			pointer_move_messager = GetComponent<PointerMoveMessager>();
		}
	}
}