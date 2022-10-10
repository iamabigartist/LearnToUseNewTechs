using UnityEngine;
namespace Labs.ExamUGUI
{
	[RequireComponent(typeof(RectTransform))]
	public class MouseIconUGUI:MonoBehaviour
	{
		void Update()
		{
			transform.position = Input.mousePosition;
		}
	}
}