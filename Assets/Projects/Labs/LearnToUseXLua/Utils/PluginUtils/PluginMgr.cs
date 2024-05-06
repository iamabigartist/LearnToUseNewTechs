using System;
using System.Collections.Generic;
using UnityEditor;
namespace Labs.LearnToUseXLua.Utils
{

public class PluginMgr<TPluginInterface> : ScriptableSingleton<PluginMgr<TPluginInterface>>
{
	public static void RegisterPlugin(Func<TPluginInterface> constructor)
	{
		instance.PluginList.Add(constructor);
	}
	public List<Func<TPluginInterface>> PluginList = new();
}
}