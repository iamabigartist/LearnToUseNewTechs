using UnityEngine;
using UnityEngine.UIElements;
namespace Labs.ExamUI.ExamNewUITools
{
public class ToggleB : VisualElement
{
	Clickable clickable;
	public ToggleB()
	{
		clickable = new(OnClick);
		focusable = true;
		tabIndex = 0;

		this.AddManipulator(clickable);

		style.height = 20;
		style.width = 20;
		style.backgroundColor = Color.red;
	}
	void OnClick()
	{
		Debug.Log("OnClick");
	}
}
}