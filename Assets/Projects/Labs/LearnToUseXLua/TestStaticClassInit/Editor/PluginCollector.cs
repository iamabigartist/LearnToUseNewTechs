using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace Labs.LearnToUseXLua.TestStaticClassInit
{
public static class PluginCollector
{
	static List<Type> register_list = new List<Type>();
	public static void Register(Type plugin)
	{
		register_list.Add(typeof(object));
	}
	[MenuItem("Labs/LearnToUseXLua/TestStaticClassInit/PluginCollector/PrintRegisterList")]
	public static void PrintRegisterList()
	{
		Debug.Log("PrintRegisterList");
		foreach (var plugin in register_list) { Debug.Log(plugin); }
	}
}
}