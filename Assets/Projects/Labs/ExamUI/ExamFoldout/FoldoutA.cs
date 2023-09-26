using System;
using UnityEngine;
using UnityEngine.UIElements;
namespace Labs.ExamUI.ExamFoldout
{
public class FoldoutA: VisualElement
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

	void SwitchValue()
	{
		value = !value;
	}

	void OnClick()
	{
		SwitchValue();
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

	void InitIcon()
	{
		icon = new();
		hierarchy.Add(icon);
	}
	void InitStyle()
	{
		styleSheets.Add(Resources.Load<StyleSheet>("ToggleA"));
	}
	void InitToggleValue(bool init_value)
	{
		value = init_value;
		icon.AddToClassList(IconUssName);
		icon.AddToClassList(value ? IconOnUssName : IconOffUssName);
	}
	void InitManipulator()
	{
		this.AddManipulator(new Clickable(OnClick));
	}
	public FoldoutA()
	{
		InitIcon();
		InitToggleValue(true);
		InitManipulator();
		InitStyle();
	}

#endregion

#region Interface

	public bool Value;
	public Action<bool> OnValueChanged;
	public override VisualElement contentContainer => icon;
	public void SetValue(bool new_value, bool notify)
	{
		value = new_value;
		if (notify) { OnValueChanged?.Invoke(value); }
		ChangeIconClassName();
	}

#endregion

#region UXML

	public new class UxmlFactory : UxmlFactory<ToggleA, UxmlTraits> {}
	public new class UxmlTraits : VisualElement.UxmlTraits
	{
		UxmlBoolAttributeDescription m_Value = new() { name = "value", defaultValue = true };
		public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
		{
			base.Init(ve, bag, cc);
			if (ve is not ToggleA toggle) { return; }
			toggle.SetValue(m_Value.GetValueFromBag(bag, cc), false);
		}
	}

#endregion
}
}