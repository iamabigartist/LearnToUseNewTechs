using UnityEngine;
namespace Labs.ExamUI.ExamUGUI
{
	public class IconPanel : MonoBehaviour
	{
		public void Create() {}
		public void IconUpdate()
		{
			transform.position = Input.mousePosition;
		}
		public void OnPick(SlotPanel PickedPanel) {}
		public void Show() {}
		public void Hide() {}
		public void OnDrop() {}
	}
}