using System;
using UnityEngine;
using UnityEngine.EventSystems;
namespace Labs.ExamUI.ExamUGUI
{
	public class PointerMoveMessager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		public event Action<GameObject, PointerEventData> PointerEnter;
		public event Action<GameObject, PointerEventData> PointerExit;
		public void OnPointerEnter(PointerEventData eventData)
		{
			PointerEnter?.Invoke(gameObject, eventData);
		}
		public void OnPointerExit(PointerEventData eventData)
		{
			PointerExit?.Invoke(gameObject, eventData);
		}
	}
}