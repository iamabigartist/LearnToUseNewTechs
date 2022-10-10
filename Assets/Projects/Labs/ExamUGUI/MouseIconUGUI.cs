using System;
using UnityEngine;
[RequireComponent(typeof(RectTransform))]
public class MouseIconUGUI:MonoBehaviour
{
	void Update()
	{
		transform.position = Input.mousePosition;
	}
}