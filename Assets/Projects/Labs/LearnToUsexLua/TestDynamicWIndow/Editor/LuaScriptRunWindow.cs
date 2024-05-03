using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Labs.LearnToUseXLua.LuaTblTreeView;
using Labs.LearnToUseXLua.TestDynamicWindow.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using XLua;
public class LuaScriptRunWindow : EditorWindow
{
	[MenuItem("Labs/LuaScriptRunWindow")]
	public static void ShowExample()
	{
		LuaScriptRunWindow wnd = GetWindow<LuaScriptRunWindow>();
		wnd.titleContent = new("LuaScriptRunWindow");
	}

	SerializedObject this_so;
	LuaEnv lua_env;
	[SerializeField] string cur_script;

	MultiColumnTreeView tree_view;
	Label GenTreeLabel()
	{
		var label = new Label();
		label.style.unityTextAlign = TextAnchor.MiddleLeft;
		label.style.flexGrow = 1;
		label.selection.isSelectable = true;
		return label;
	}
	public void CreateGUI()
	{
		var a = Resources.Load<StyleSheet>("");
		var builder = new UXMLBuilder(rootVisualElement);
		builder.Add(out var root_panel, new VisualElement());
		root_panel.style.marginLeft = root_panel.style.marginRight = root_panel.style.marginTop = root_panel.style.marginBottom = 10;
		using (builder.Scope(root_panel))
		{
			builder.Add(out _, new Label("Script"));

			builder.Add(out var script_field, new TextField());
			script_field.multiline = true;
			script_field.style.height = 300;
			script_field.bindingPath = "cur_script";

			builder.Add(out var run_button, new Button(RunCurScript));
			run_button.text = "Run";

			builder.Add(out var get_gtbl_button, new Button(() => GetGTblView()));
			get_gtbl_button.text = "Get Global Table";

			builder.Add(out tree_view, new());
			tree_view.reorderable = false;
			tree_view.fixedItemHeight = 80;
			tree_view.columns.Add(new()
			{
				title = "key",
				minWidth = 100,
				maxWidth = 200,
				stretchable = true,
				sortable = true,
				makeCell = () =>
				{
					return GenTreeLabel();
				},
				bindCell = (ve, idx) =>
				{
					var item = tree_view.GetItemDataForIndex<LuaViewItemData>(idx);
					var label = ve as Label;
					label.text = item.key;
				}
			});

			tree_view.columns.Add(new()
			{
				title = "type",
				minWidth = 50,
				maxWidth = 100,
				stretchable = true,
				sortable = true,
				makeCell = () =>
				{
					return GenTreeLabel();
				},
				bindCell = (ve, idx) =>
				{
					var item = tree_view.GetItemDataForIndex<LuaViewItemData>(idx);
					var label = ve as Label;
					label.text = item.type;
				}
			});

			tree_view.columns.Add(new()
			{
				title = "value",
				minWidth = 400,
				stretchable = true,
				sortable = true,
				makeCell = () =>
				{
					return GenTreeLabel();
				},
				bindCell = (ve, idx) =>
				{
					var item = tree_view.GetItemDataForIndex<LuaViewItemData>(idx);
					var label = ve as Label;
					try { label.text = item.value; }
					catch (Exception e) { label.text = e.Message; }
				}
			});
		}
		rootVisualElement.Bind(this_so);
	}

	void OnEnable()
	{
		this_so = new(this);
		lua_env = new();
		lua_env.DoString(File.ReadAllText("Assets/Projects/Labs/LearnToUseXLua/LuaTableTreeView/LuaDataView.lua"));
		get_data_view = lua_env.Global.Get<GetDataViewDelegate>("GetViewData");
	}

	void OnDisable()
	{
		get_data_view = null;
		lua_env.Dispose();
	}

	void RunCurScript()
	{
		lua_env.DoString(cur_script);
	}

	[CSharpCallLua]
	delegate LuaViewItemData GetDataViewDelegate(object obj);
	GetDataViewDelegate get_data_view;

	TreeViewItemData<LuaViewItemData> LuaData2TreeViewData(LuaViewItemData root_item, ref int tree_item_idx)
	{
		List<TreeViewItemData<LuaViewItemData>> children = null;
		if (root_item.type == "table")
		{
			children = new();
			foreach (var (key, value) in root_item.children)
			{
				children.Add(LuaData2TreeViewData(value, ref tree_item_idx));
			}
		}
		var tree_item = new TreeViewItemData<LuaViewItemData>(tree_item_idx++, root_item, children);
		return tree_item;
	}

	void GetGTblView()
	{
		var tbl = lua_env.Global.Get<LuaTable>("_G");
		var data_tbl = get_data_view(tbl);
		var tree_item_idx = 0;
		var tree_data = LuaData2TreeViewData(data_tbl, ref tree_item_idx);
		tree_view.SetRootItems(tree_data.children.ToList());
		tree_view.Rebuild();
	}
}