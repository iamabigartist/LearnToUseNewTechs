using UnityEngine;
namespace Labs.ExamUI.ExamUGUI
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