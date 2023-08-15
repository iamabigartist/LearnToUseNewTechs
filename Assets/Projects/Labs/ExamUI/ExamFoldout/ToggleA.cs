using UnityEngine.UIElements;
namespace Labs.ExamUI.ExamFoldout
{
public class ToggleA : VisualElement
{

	public const string UssName = "toggle-a";
	public const string IconOnUssName = UssName + "__icon-on";
	public const string IconOffUssName = UssName + "__icon-off";

#region Init

	void InitStyle()
	{
		tabIndex = 0;
		focusable = true;
	}

	public ToggleA() {}

#endregion

}
}