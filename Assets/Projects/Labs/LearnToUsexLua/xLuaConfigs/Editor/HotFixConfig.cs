using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using XLua;
using static Labs.LearnToUseXLua.xLuaConfigs.XLuaConfigUtil;
namespace Labs.LearnToUseXLua.xLuaConfigs
{
public static class HotFixConfig
{
	/***************热补丁可以参考这份自动化配置***************/
	[Hotfix]
	static IEnumerable<Type> HotfixInject
	{
		get
		{
			return from type in Assembly.Load("Assembly-CSharp").GetTypes()
				where type.Namespace == null || !type.Namespace.StartsWith("XLua")
				select type;
		}
	}
	//--------------begin 热补丁自动化配置-------------------------
	

	// 配置某Assembly下所有涉及到的delegate到CSharpCallLua下，Hotfix下拿不准那些delegate需要适配到lua function可以这么配置
	// [CSharpCallLua]
	// static IEnumerable<Type> AllDelegate
	// {
	// 	get
	// 	{
	// 		BindingFlags flag = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;
	// 		List<Type> allTypes = new List<Type>();
	// 		var allAssemblys = new Assembly[]
	// 		{
	// 			Assembly.Load("Assembly-CSharp")
	// 		};
	// 		foreach (var t in from assembly in allAssemblys from type in assembly.GetTypes() select type)
	// 		{
	// 			var p = t;
	// 			while (p != null)
	// 			{
	// 				allTypes.Add(p);
	// 				p = p.BaseType;
	// 			}
	// 		}
	// 		allTypes = allTypes.Distinct().ToList();
	// 		var allMethods = from type in allTypes
	// 			from method in type.GetMethods(flag)
	// 			select method;
	// 		var returnTypes = from method in allMethods
	// 			select method.ReturnType;
	// 		var paramTypes = allMethods.SelectMany(m => m.GetParameters()).Select(pinfo => pinfo.ParameterType.IsByRef ? pinfo.ParameterType.GetElementType() : pinfo.ParameterType);
	// 		var fieldTypes = from type in allTypes
	// 			from field in type.GetFields(flag)
	// 			select field.FieldType;
	// 		return returnTypes.Concat(paramTypes).Concat(fieldTypes).Where(t => t.BaseType == typeof(MulticastDelegate) && !hasGenericParameter(t) && !delegateHasEditorRef(t)).Distinct();
	// 	}
	// }
	//--------------end 热补丁自动化配置-------------------------
}
}