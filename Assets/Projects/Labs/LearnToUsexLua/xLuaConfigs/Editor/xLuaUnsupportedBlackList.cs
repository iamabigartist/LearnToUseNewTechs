using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using XLua;
namespace Labs.LearnToUseXLua.xLuaConfigs
{
public static class XLuaUnsupportedBlackList
{
	//黑名单
	[BlackList]
	public static List<List<string>> BlackList = new()
	{
		new() { "System.Xml.XmlNodeList", "ItemOf" },
		new() { "UnityEngine.WWW", "movie" },
    #if UNITY_WEBGL
                new List<string>(){"UnityEngine.WWW", "threadPriority"},
    #endif
		new() { "UnityEngine.Texture2D", "alphaIsTransparency" },
		new() { "UnityEngine.Security", "GetChainOfTrustValue" },
		new() { "UnityEngine.CanvasRenderer", "onRequestRebuild" },
		new() { "UnityEngine.Light", "areaSize" },
		new() { "UnityEngine.Light", "lightmapBakeType" },
		new() { "UnityEngine.WWW", "MovieTexture" },
		new() { "UnityEngine.WWW", "GetMovieTexture" },
		new() { "UnityEngine.AnimatorOverrideController", "PerformOverrideClipListCleanup" },
    #if !UNITY_WEBPLAYER
		new() { "UnityEngine.Application", "ExternalEval" },
    #endif
		new() { "UnityEngine.GameObject", "networkView" }, //4.6.2 not support
		new() { "UnityEngine.Component", "networkView" }, //4.6.2 not support
		new() { "System.IO.FileInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections" },
		new() { "System.IO.FileInfo", "SetAccessControl", "System.Security.AccessControl.FileSecurity" },
		new() { "System.IO.DirectoryInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections" },
		new() { "System.IO.DirectoryInfo", "SetAccessControl", "System.Security.AccessControl.DirectorySecurity" },
		new() { "System.IO.DirectoryInfo", "CreateSubdirectory", "System.String", "System.Security.AccessControl.DirectorySecurity" },
		new() { "System.IO.DirectoryInfo", "Create", "System.Security.AccessControl.DirectorySecurity" },
		new() { "UnityEngine.MonoBehaviour", "runInEditMode" }
	};

#if UNITY_2018_1_OR_NEWER
	[BlackList]
	public static Func<MemberInfo, bool> MethodFilter = (memberInfo) =>
	{
		if (memberInfo.DeclaringType.IsGenericType && memberInfo.DeclaringType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
		{
			if (memberInfo.MemberType == MemberTypes.Constructor)
			{
				ConstructorInfo constructorInfo = memberInfo as ConstructorInfo;
				var parameterInfos = constructorInfo.GetParameters();
				if (parameterInfos.Length > 0)
				{
					if (typeof(IEnumerable).IsAssignableFrom(parameterInfos[0].ParameterType))
					{
						return true;
					}
				}
			}
			else if (memberInfo.MemberType == MemberTypes.Method)
			{
				var methodInfo = memberInfo as MethodInfo;
				if (methodInfo.Name == "TryAdd" || (methodInfo.Name == "Remove" && methodInfo.GetParameters().Length == 2))
				{
					return true;
				}
			}
		}
		return false;
	};
#endif
}
}