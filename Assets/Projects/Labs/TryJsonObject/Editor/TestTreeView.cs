using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
namespace Labs.TryJsonObject.Editor
{
public class TestTreeView : EditorWindow
{

#region SerializedData

	[SerializeField] VisualTreeAsset m_VisualTreeAsset = default;

#endregion

#region Reference

	TreeView tree_view;

#endregion

#region Data

	List<string> infos = new()
	{
		"asd",
		"asdasd",
		"aaddd"
	};

#endregion

#region Process

	List<TreeViewItemData<int>> Test0TreeData()
	{
		int i = 0;
		return new()
		{
			new(i++, i, new()
			{
				new(i++, i),
				new(i++, i, new()
				{
					new(i++, i),
					new(i++, i)
				})
			}),
			new(i++, i, new()
			{
				new(i++, i),
				new(i++, i),
				new(i++, i)
			})
		};
	}

#endregion

#region UnityCallBack

	[MenuItem("Labs/TestTreeView")]
	public static void ShowExample()
	{
		TestTreeView wnd = GetWindow<TestTreeView>();
		wnd.titleContent = new("TestTreeView");
	}

	void Awake() {}

	public void CreateGUI()
	{
		var root = rootVisualElement;
		var uxml = m_VisualTreeAsset.Instantiate();
		root.Add(uxml);
		tree_view = uxml.Q<TreeView>();
		tree_view.horizontalScrollingEnabled = true;
		tree_view.SetRootItems(Test0TreeData());
		tree_view.makeItem = () =>
		{
			var container = new VisualElement();
			container.AddToClassList("view-container");
			container.Add(new Label());
			return container;
		};
		tree_view.bindItem = (element, i) =>
		{
			var l = element.Q<Label>();
			l.text = $"{tree_view.GetItemDataForIndex<int>(i)}";
		};
	}

#endregion

}
}