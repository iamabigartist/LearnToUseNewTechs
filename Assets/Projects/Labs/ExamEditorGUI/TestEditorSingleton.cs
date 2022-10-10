using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class MySingletonWindow : EditorWindow
{
	// static string ToLiteral(string valueTextForCompiler)
	// {
	// 	return SymbolDisplay.FormatLiteral(valueTextForCompiler, false);
	// }
	static bool EnsureDirectory(string Path)
	{
		var exist = Directory.Exists(Path);
		if (!exist)
		{
			Debug.Log($"Create Directory {Path}");
			Directory.CreateDirectory(Path);
		}
		return exist;
	}
	static string EnsureLineEnding(string input)
	{
		return Regex.Replace(input, "\r\n|\r|\n", Environment.NewLine);
	}

	public EditorWindow MouseOverWindow;
	public EditorWindow FocusWindow;
	public Object SelectedObject;
	[MenuItem("SingletonTest/Monitor")]
	static void Init()
	{
		// CreateWindow<MySingletonWindow>("Monitor", Type.GetType("UnityEditor.ConsoleWindow,UnityEditor.dll"));
		CreateWindow<MySingletonWindow>("Monitor");
		GetWindow(Type.GetType("UnityEditor.ConsoleWindow,UnityEditor.dll")).ShowNotification(new("asdasdasd"));
	}
	void OnEnable()
	{
		MySingleton.instance.CurrentWindow = this;
	}
	void OnDestroy()
	{
		MySingleton.instance.CurrentWindow = null;
	}

	void OnInspectorUpdate()
	{
		Repaint();
	}
	void OnGUI()
	{
		GeneratedNamespace.GeneratedClass.GeneratedMethod();

		EditorGUILayout.LabelField($"MouseOverWindow: {(MouseOverWindow != null ? MouseOverWindow.ToString() : "None")}");
		EditorGUILayout.LabelField($"FocusWindow: {(FocusWindow != null ? FocusWindow.ToString() : "None")}");
		EditorGUILayout.LabelField($"SelectedObject: {(SelectedObject != null ? SelectedObject.ToString() : "None")}");
	}
}

[FilePath("EditorSystem/StateFile.asset", FilePathAttribute.Location.ProjectFolder)]
public class MySingleton : ScriptableSingleton<MySingleton>
{
	public float m_Number = 42;
	public List<string> m_Strings = new();
	public MySingletonWindow CurrentWindow;
	double check_time;
	void OnEnable()
	{
		EditorApplication.update += Update;
		check_time = EditorApplication.timeSinceStartup;
		TestGen.MyGen();

	}
	void OnDisable()
	{
		EditorApplication.update -= Update;
	}

	public void Update()
	{
		// Debug.Log(EditorWindow.mouseOverWindow);
		if (CurrentWindow != null)
		{
			CurrentWindow.FocusWindow = EditorWindow.focusedWindow;
			CurrentWindow.MouseOverWindow = EditorWindow.mouseOverWindow;
			CurrentWindow.SelectedObject = Selection.activeObject;
		}

		if (EditorApplication.timeSinceStartup > check_time)
		{
			check_time = EditorApplication.timeSinceStartup + 2;
			if (TestGen.NeedRegen)
			{
				TestGen.MyGen();
			}
		}
	}

	public void Modify()
	{
		m_Number *= 2;
		m_Strings.Add("Foo" + m_Number);

		Save(true);
		Debug.Log("Saved to: " + GetFilePath());
	}

	public void Log()
	{
		Debug.Log("MySingleton state: " + JsonUtility.ToJson(this, true));
	}
}


static class MySingletonMenuItems
{
	[MenuItem("SingletonTest/Log")]
	static void LogMySingletonState()
	{
		MySingleton.instance.Log();
	}

	[MenuItem("SingletonTest/Modify")]
	static void ModifyMySingletonState()
	{
		MySingleton.instance.Modify();
	}
}