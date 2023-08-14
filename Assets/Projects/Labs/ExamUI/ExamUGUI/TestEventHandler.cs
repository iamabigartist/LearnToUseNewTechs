using UnityEngine;
using UnityEngine.EventSystems;
namespace Labs.ExamUI.ExamUGUI
{
	public class TestEventHandler :MonoBehaviour,IPointerUpHandler,IPointerDownHandler
	{
		public void OnPointerUp(PointerEventData eventData)
		{
			Debug.Log($"Up {gameObject.name}");
		}
		public void OnPointerDown(PointerEventData eventData)
		{
			Debug.Log($"Down {gameObject.name}");
		}
	}
}