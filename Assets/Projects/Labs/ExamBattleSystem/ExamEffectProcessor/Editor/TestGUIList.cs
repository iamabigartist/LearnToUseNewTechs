using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
namespace Labs.ExamEffectProcessor.Editor
{
	public class TestGUIList : EditorWindow
	{
		[MenuItem("Labs/Labs.ExamEffectProcessor.Editor/TestGUIList")]
		static void ShowWindow()
		{
			var window = GetWindow<TestGUIList>();
			window.titleContent = new("TestGUIList");
			window.wantsMouseMove = true;
			window.Show();
		}

		List<string> m_list;

		void OnEnable()
		{
			m_list = new()
			{
				"aasad",
				"asdas\nasdas",
				"asd"
			};
		}

		VisualElement CreateElement()
		{
			return new TextField
			{
				multiline = true,
				style =
				{
					paddingBottom = 10,
					paddingTop = 10
				}
			};
		}

		void MakeElement(VisualElement ve, int i)
		{
			var t = (TextField)ve;
			t.SetValueWithoutNotify(m_list[i]);
			t.RegisterValueChangedCallback(e =>
			{
				m_list[i] = e.newValue;
			});


			t.tooltip = "asdasd";
		}

		Label label;
		Label info_label;
		void CreateGUI()
		{
			label = new("Mouse me")
			{
				style = { position = Position.Absolute }
			};
			var list_view = new ListView(m_list, 100, CreateElement, MakeElement) { showAddRemoveFooter = true };
			info_label = new();
			rootVisualElement.Add(list_view);
			rootVisualElement.Add(info_label);
			rootVisualElement.Add(label);
		}

		Vector2 read_mouse_pos;
		Vector2 corrected_mouse_pos;

		void OnGUI()
		{
			// read_mouse_pos = Mouse.current.position.ReadUnprocessedValue();
			read_mouse_pos = Event.current.mousePosition;
			corrected_mouse_pos = read_mouse_pos;
		}

		void Update()
		{
			Repaint();

			// var ve_mouse_pos = rootVisualElement.worldTransform.MultiplyPoint(corrected_mouse_pos);
			var ve_mouse_pos = corrected_mouse_pos;
			label.style.left = ve_mouse_pos.x;
			label.style.top = ve_mouse_pos.y;

			info_label.text = JsonConvert.SerializeObject(new
			{
				read_mouse_pos = read_mouse_pos.ToString(),
				corrected_mouse_pos = corrected_mouse_pos.ToString(),
				ve_mouse_pos = ve_mouse_pos.ToString()
			}, Formatting.Indented);


		}
	}
}