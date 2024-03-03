using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.EditorGUILayout;
using static UnityEngine.GUILayout;
namespace Labs.TrySheetEditor
{

public class TestSheetWindow : EditorWindow
{
	[MenuItem("Labs/TestSheetWindow")]
	static void Open()
	{
		var window = GetWindow<TestSheetWindow>();
		window.name = "TestSheetWindow";
	}

	delegate void RenderRowItem(int idx, float width);

	void SheetRowRender(List<float> item_width_list, List<RenderRowItem> item_render_list)
	{
		using (var h = new EditorGUILayout.HorizontalScope(GUI.skin.box))
		{
			for (int i = 0; i < item_render_list.Count; i++)
			{
				var cur_item_render = item_render_list[i];
				var cur_item_width = item_width_list[i];
				cur_item_render(i, cur_item_width);
				if (i < item_render_list.Count - 1)
				{
					Box("", GUI.skin.button,Width(1));
				}
			}
		}
	}

	void IDPopUpRender(int idx, float width, (Func<List<string>> get_list, Func<int> get_cur, Action<int> set) id)
	{
		var res_id = Popup(id.get_cur(), id.get_list().ToArray(), Width(width));
		id.set(res_id);
	}

	void TextInputRender(int idx, float width, (Func<string> get, Action<string> set) text)
	{
		var res_text = EditorGUILayout.TextField(text.get(), Width(width));
		text.set(res_text);
	}

	void FloatFieldRender(int idx, float width, (Func<float> get, Action<float> set) value)
	{
		var res_value = FloatField(value.get(), Width(width));
		value.set(res_value);
	}
	void IntFieldRender(int idx, float width, (Func<int> get, Action<int> set) value)
	{
		var res_value = IntField(value.get(), Width(width));
		value.set(res_value);
	}

	void LabelRender(int idx, float width, string label)
	{
		Label(label, Width(width));
	}

	//请描述一把远程武器所拥有的属性
	//ID,名称,穿甲类型,攻击力,射程,弹药

	//根据以上描述的属性，生成所有需要的数据字段
	public class WeaponData
	{
		public static List<string> ArmorPiercingTypeList = new()
			{ "无", "轻甲穿透", "重甲穿透", "爆炸减甲" };
		public int ID;
		public string Name;
		public int ArmorPiercingType;
		public float Attack;
		public float Range;
		public int Ammo;
	}

	WeaponData w0;
	List<float> item_width_list = new()
		{ 50, 100, 100, 100, 100, 100 };

	List<RenderRowItem> item_label_list;
	List<RenderRowItem> item_gui_list;
	void OnEnable()
	{
		w0 = new();
		item_label_list = new()
		{
			(idx, width) => LabelRender(idx, width, "ID"),
			(idx, width) => LabelRender(idx, width, "名称"),
			(idx, width) => LabelRender(idx, width, "穿甲类型"),
			(idx, width) => LabelRender(idx, width, "攻击力"),
			(idx, width) => LabelRender(idx, width, "射程"),
			(idx, width) => LabelRender(idx, width, "弹药")
		};
		item_gui_list = new()
		{
			(idx, width) => IntFieldRender(idx, width, (() => w0.ID, (v) => w0.ID = v)),
			(idx, width) => TextInputRender(idx, width, (() => w0.Name, (v) => w0.Name = v)),
			(idx, width) => IDPopUpRender(idx, width, (() => WeaponData.ArmorPiercingTypeList, () => w0.ArmorPiercingType, (v) => w0.ArmorPiercingType = v)),
			(idx, width) => FloatFieldRender(idx, width, (() => w0.Attack, (v) => w0.Attack = v)),
			(idx, width) => FloatFieldRender(idx, width, (() => w0.Range, (v) => w0.Range = v)),
			(idx, width) => IntFieldRender(idx, width, (() => w0.Ammo, (v) => w0.Ammo = v))
		};
	}

	void OnGUI()
	{
		SheetRowRender(item_width_list, item_label_list);
		SheetRowRender(item_width_list, item_gui_list);
	}


}
}