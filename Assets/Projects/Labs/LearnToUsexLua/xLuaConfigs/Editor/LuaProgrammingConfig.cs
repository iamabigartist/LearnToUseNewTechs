using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using XLua;
using static Labs.LearnToUseXLua.xLuaConfigs.XLuaConfigUtil;
namespace Labs.LearnToUseXLua.xLuaConfigs
{
public static class LuaProgrammingConfig
{

	static bool isExcluded(List<string> exclude_list, Type type)
	{
		var fullName = type.FullName;
		for (int i = 0; i < exclude_list.Count; i++)
		{
			if (fullName.Contains(exclude_list[i]))
			{
				return true;
			}
		}
		return false;
	}

	/***************如果你全lua编程，可以参考这份自动化配置***************/
	//--------------begin 纯lua编程配置参考----------------------------
	static List<string> exclude_LuaCallCsharp = new()
	{
		"HideInInspector", "ExecuteInEditMode",
		"AddComponentMenu", "ContextMenu",
		"RequireComponent", "DisallowMultipleComponent",
		"SerializeField", "AssemblyIsEditorAssembly",
		"Attribute", "Types",
		"UnitySurrogateSelector", "TrackedReference",
		"TypeInferenceRules", "FFTWindow",
		"RPC", "Network", "MasterServer",
		"BitStream", "HostData",
		"ConnectionTesterStatus", "GUI", "EventType",
		"EventModifiers", "FontStyle", "TextAlignment",
		"TextEditor", "TextEditorDblClickSnapping",
		"TextGenerator", "TextClipping", "Gizmos",
		"ADBannerView", "ADInterstitialAd",
		"Android", "Tizen", "jvalue",
		"iPhone", "iOS", "Windows", "CalendarIdentifier",
		"CalendarUnit", "CalendarUnit",
		"ClusterInput", "FullScreenMovieControlMode",
		"FullScreenMovieScalingMode", "Handheld",
		"LocalNotification", "NotificationServices",
		"RemoteNotificationType", "RemoteNotification",
		"SamsungTV", "TextureCompressionQuality",
		"TouchScreenKeyboardType", "TouchScreenKeyboard",
		"MovieTexture", "UnityEngineInternal",
		"Terrain", "Tree", "SplatPrototype",
		"DetailPrototype", "DetailRenderMode",
		"MeshSubsetCombineUtility", "AOT", "Social", "Enumerator",
		"SendMouseEvents", "Cursor", "Flash", "ActionScript",
		"OnRequestRebuild", "Ping",
		"ShaderVariantCollection", "SimpleJson.Reflection",
		"CoroutineTween", "GraphicRebuildTracker",
		"Advertisements", "UnityEditor", "WSA",
		"EventProvider", "Apple",
		"ClusterInput", "Motion",
		"UnityEngine.UI.ReflectionMethodsCache", "NativeLeakDetection",
		"NativeLeakDetectionMode", "WWWAudioExtensions", "UnityEngine.Experimental"
	};

	[LuaCallCSharp]
	public static IEnumerable<Type> LuaCallCSharp
	{
		get
		{
			List<string> namespaces = new List<string>() // 在这里添加名字空间
			{
				// "System",
				"UnityEngine",
				"UnityEngine.UI"
			};
			var unityTypes = from assembly in AppDomain.CurrentDomain.GetAssemblies()
				where !(assembly.ManifestModule is ModuleBuilder)
				from type in assembly.GetExportedTypes()
				where type.Namespace != null && namespaces.Contains(type.Namespace) && !isExcluded(exclude_LuaCallCsharp, type)
					&& type.BaseType != typeof(MulticastDelegate) && !type.IsInterface && !type.IsEnum
				select type;

			string[] customAssembles = new string[]
			{
				"Assembly-CSharp"
			};
			var customTypes = from assembly in customAssembles.Select(s => Assembly.Load(s))
				from type in assembly.GetExportedTypes()
				where type.Namespace == null || (!type.Namespace.StartsWith("XLua")
					&& type.BaseType != typeof(MulticastDelegate) && !type.IsInterface && !type.IsEnum)
				select type;
			return unityTypes.Concat(customTypes);
		}
	}

	static List<string> exclude_CSharpCallLua = new()
		{ "MemoryUsage" };

	//自动把LuaCallCSharp涉及到的delegate加到CSharpCallLua列表，后续可以直接用lua函数做callback
	[CSharpCallLua]
	public static List<Type> CSharpCallLua
	{
		get
		{
			var lua_call_csharp = LuaCallCSharp;
			var delegate_types = new List<Type>();
			var flag = BindingFlags.Public | BindingFlags.Instance
				| BindingFlags.Static | BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly;
			foreach (var field in (from type in lua_call_csharp select type).SelectMany(type => type.GetFields(flag)))
			{
				if (typeof(Delegate).IsAssignableFrom(field.FieldType))
				{
					delegate_types.Add(field.FieldType);
				}
			}

			foreach (var method in (from type in lua_call_csharp select type).SelectMany(type => type.GetMethods(flag)))
			{
				if (typeof(Delegate).IsAssignableFrom(method.ReturnType))
				{
					delegate_types.Add(method.ReturnType);
				}
				foreach (var param in method.GetParameters())
				{
					var paramType = param.ParameterType.IsByRef ? param.ParameterType.GetElementType() : param.ParameterType;
					if (typeof(Delegate).IsAssignableFrom(paramType))
					{
						delegate_types.Add(paramType);
					}
				}
			}
			return delegate_types.Where(t => t.BaseType == typeof(MulticastDelegate) && !hasGenericParameter(t) && !delegateHasEditorRef(t) && !isExcluded(exclude_CSharpCallLua, t)).Distinct().ToList();
		}
	}
	//--------------end 纯lua编程配置参考----------------------------
}
}