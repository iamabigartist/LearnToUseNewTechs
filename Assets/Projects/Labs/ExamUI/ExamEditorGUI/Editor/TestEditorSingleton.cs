using System;
using System.Collections.Generic;
using Labs.ExamUI.ExamUGUI;
using PrototypePackages.MiscUtils;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;
using static PrototypePackages.TimeUtils.CounterUtil<float>;
using Object = UnityEngine.Object;
namespace Labs.ExamUI.ExamEditorGUI
{
	public class MySingletonWindow : EditorWindow
	{
		[MenuItem("SingletonTest/Monitor")]
		static void Init()
		{
			// CreateWindow<MySingletonWindow>("Monitor", Type.GetType("UnityEditor.ConsoleWindow,UnityEditor.dll"));
			CreateWindow<MySingletonWindow>("Monitor");
			GetWindow(Type.GetType("UnityEditor.ConsoleWindow,UnityEditor.dll")).ShowNotification(new("asdasdasd"));
		}

		public EditorWindow MouseOverWindow;
		public EditorWindow FocusWindow;
		public Object SelectedObject;
		public Object SelectedContextObject;

		bool Showing => MySingleton.instance.CurrentWindow == this;

		CountFor CountFor;
		Counter ui_update;

		void OnEnable()
		{
			// Debug.Log("OnEnable");
			MySingleton.instance.CurrentWindow = this;
			CountFor = CreateCounterKind(() => (float)EditorApplication.timeSinceStartup);
		}

		void OnDisable()
		{
			// Debug.Log("OnDisable");
			MySingleton.instance.CurrentWindow = null;
		}

		void Update()
		{
			if (Showing) { ui_update.Elapsed(); }
		}

		void CreateGUI()
		{
			// Debug.Log("CreateGUI");
			Label context_label = new() { focusable = true };
			Label mouse_over_window_label = new() { focusable = true };
			Label focus_window_label = new() { focusable = true };
			Label selected_object_label = new() { focusable = true };
			ScrollView scroll_view = new(ScrollViewMode.VerticalAndHorizontal);
			scroll_view.contentContainer.Set4Padding(10f);
			scroll_view.Add(context_label, mouse_over_window_label, focus_window_label, selected_object_label);
			ui_update = CountFor(0.1f,
				_ =>
				{
					context_label.text = $"main_stage_path: {StageUtility.GetMainStage().assetPath}";
				},
				_ => mouse_over_window_label.text = $"MouseOverWindow: {(MouseOverWindow != null ? MouseOverWindow.ToString() : "None")}",
				_ => focus_window_label.text = $"FocusWindow: {(FocusWindow != null ? FocusWindow.ToString() : "None")}",
				_ => selected_object_label.text = $"Selected Context Object: {(SelectedContextObject != null ? SelectedContextObject.ToString() : "None")}\n" +
					$"SelectedObject: {(SelectedObject != null ? SelectedObject.ToString() : "None")}");
			rootVisualElement.Add(scroll_view);
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
				CurrentWindow.SelectedContextObject = Selection.activeContext;
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
}