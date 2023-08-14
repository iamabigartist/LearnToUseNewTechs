using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Labs.ExamEditorGUI
{
	public static class TestPing
	{
		[MenuItem("Examples/Ping Selected")]
		static void Ping()
		{
			if (!Selection.activeObject)
			{
				Debug.Log("Select an object to ping");
				return;
			}

			EditorGUIUtility.PingObject(Selection.activeObject);
		}

		[MenuItem("Examples/Highlight Something")]
		static async void HighlightSomething()
		{
			Highlighter.Highlight("Project", "LearnAlgebra", HighlightSearchMode.Auto);
			await Task.Delay(500);
			Highlighter.Stop();
		}

		[Shortcut("HighlightSceneContext")]
		[MenuItem("Examples/Highlight Scene Context")]
		static void HighlightSceneContext()
		{
			var path = SceneManager.GetActiveScene().path;
			var asset = AssetDatabase.LoadAssetAtPath<Object>(path);
			EditorGUIUtility.PingObject(asset);
		}
	}
}