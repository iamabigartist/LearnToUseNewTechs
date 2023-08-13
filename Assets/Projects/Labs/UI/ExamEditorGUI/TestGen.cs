using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using static System.IO.Path;
using static UnityEditor.AssetDatabase;
using static UnityEngine.Application;
public static class TestGen
{
	const string GENERATED_PATH = "GeneratedSource";
	public static string[] last_tags;
	public static bool NeedRegen => !last_tags.SequenceEqual(InternalEditorUtility.tags);
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

	[MenuItem("CodeGen/GenExample")]
	public static void MyGen()
	{
		var work_directory = dataPath;
		var tags = InternalEditorUtility.tags;
		last_tags = tags;
		var tag_fields = new List<string>();

		foreach (var tag in tags)
		{
			var tag_field = @$" public const string {tag}=""{tag}""; ";
			tag_fields.Add(tag_field);
		}

		var script = @$"
public static class UnityTags
{{
{string.Join("\r", tag_fields)} 
}}
";
		string result = EnsureLineEnding(script);
		EnsureDirectory(Combine(work_directory, GENERATED_PATH));
		File.WriteAllText(Combine(work_directory, Combine(GENERATED_PATH, "UnityTag.gen.cs")), result, Encoding.UTF8);
		Refresh();
	}

}