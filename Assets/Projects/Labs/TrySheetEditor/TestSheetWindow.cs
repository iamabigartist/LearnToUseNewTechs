using UnityEditor;
namespace Labs.TrySheetEditor
{
public class TestSheetWindow : EditorWindow
{
	static void Open()
	{
		var window = GetWindow<TestSheetWindow>();
	}
}
}