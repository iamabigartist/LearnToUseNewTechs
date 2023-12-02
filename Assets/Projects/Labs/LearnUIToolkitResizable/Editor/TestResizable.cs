using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
namespace Labs.LearnUIToolkitResizable
{
public class TestResizable : EditorWindow
{
	[SerializeField] VisualTreeAsset m_VisualTreeAsset = default;

	[MenuItem("Learn/UI Toolkit/TestResizable")]
	public static void ShowExample()
	{
		TestResizable wnd = GetWindow<TestResizable>();
		wnd.titleContent = new("TestResizable");
	}

	public void CreateGUI()
	{
		var root = rootVisualElement;
		root.style.paddingTop = 10;
		root.style.paddingBottom = 10;
		root.style.paddingLeft = 10;
		root.style.paddingRight = 10;
		root.Add(new ResizablePanel());
	}
}
}