using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TestEventHandler :Selectable, IPointerUpHandler,IPointerDownHandler
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