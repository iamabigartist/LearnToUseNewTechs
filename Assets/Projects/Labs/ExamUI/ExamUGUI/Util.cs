using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;
namespace Labs.ExamUI.ExamUGUI
{
	public static class Util
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

		public static EventTrigger.Entry CreateEventTriggerEntry(EventTriggerType TriggerType, params UnityAction<BaseEventData>[] callbacks)
		{
			var entry = new EventTrigger.Entry
			{
				eventID = TriggerType
			};
			foreach (var action in callbacks)
			{
				entry.callback.AddListener(action);
			}
			return entry;
		}

		public static bool IsNull(this Object obj) => obj == null;

		public static void Add(this VisualElement ve, params VisualElement[] children)
		{
			foreach (var child in children) { ve.Add(child); }
		}
	}
}