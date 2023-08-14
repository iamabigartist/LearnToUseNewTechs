using PrototypePackages.MainThreadExecutor.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static Labs.ExamUI.ExamNewUITools.TreeStructureConnect<UnityEngine.UIElements.VisualElement>;
namespace Labs.ExamUI.Editor
{
public static class TestUIs
{

	[MenuItem("Labs/ExamUI/TestTreeConstruct")]
	public static void TestTreeConstruct()
	{
		var window = new LiteEditorWindow("TestTreeConstruct")
		{
			window =
			{
				name = "TestTreeConstruct"
			}
		};
		var root = window.root;
		root.styleSheets.Add(Resources.Load<StyleSheet>("TestBox"));
		TreeConnect((parent, child) => parent.Add(child),
			(root, new Node[]
				{
					(new Box(), new Node[]
						{
							(new Label("1"), default),
							(new Box(), new Node[]
							{
								(new Label("2.1"), default),
								(new Label("2.2"), default),
								(new Box(),new Node[]
								{
									(new Label("2.3.1"), default),
									(new Label("2.3.2"), default),
								})
							}),
							(new Box(), new Node[]
							{
								(new Label("3.1"), default),
								(new Label("3.2"), default),
							})
						}
					),
				}
			)
			);
		window.Show();
	}
}
}