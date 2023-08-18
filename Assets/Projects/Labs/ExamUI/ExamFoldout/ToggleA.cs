using System;
using UnityEngine;
using UnityEngine.UIElements;
namespace Labs.ExamUI.ExamFoldout
{
public class ToggleA : VisualElement
{
	public const string UssName = "toggle-a";
	public const string IconUssName = UssName + "__icon";
	public const string IconOnUssName = UssName + "__icon-on";
	public const string IconOffUssName = UssName + "__icon-off";

#region Data

	VisualElement icon;
	bool value;

#endregion

#region Process

	void OnClick()
	{
		value = !value;
		OnValueChanged?.Invoke(value);
		ChangeIconClassName();
	}

	void ChangeIconClassName()
	{
		var remove_class_name = value ? IconOffUssName : IconOnUssName;
		var add_class_name = value ? IconOnUssName : IconOffUssName;
		icon.RemoveFromClassList(remove_class_name);
		icon.AddToClassList(add_class_name);
	}

#endregion

#region Init

	void InitStyle()
	{
		tabIndex = 0;
		focusable = true;
		styleSheets.Add(Resources.Load<StyleSheet>("ToggleA"));
	}

	public ToggleA()
	{
		InitStyle();
		value = false;
		icon = new();
		Add(icon);
		icon.AddToClassList(IconUssName);
		icon.AddToClassList(IconOffUssName);
		this.AddManipulator(new Clickable(OnClick));
	}

#endregion

#region Interface

	public VisualElement IconContainer => icon;
	public bool Value;
	public Action<bool> OnValueChanged;

#endregion

}
}