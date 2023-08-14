using System;
using UnityEngine;
namespace Labs.ExamUI.ExamUGUI
{
	public class SlotPanel : MonoBehaviour
	{
		PointerMoveMessager pointer_move_messager;
		public event Action OnCreate;
		public void Create()
		{
			pointer_move_messager = GetComponent<PointerMoveMessager>();
			OnCreate?.Invoke();
		}
	}
}