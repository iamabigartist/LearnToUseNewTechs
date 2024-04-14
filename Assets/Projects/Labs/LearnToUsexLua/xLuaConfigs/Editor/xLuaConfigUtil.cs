using System;
using System.Linq;
namespace Labs.LearnToUseXLua.xLuaConfigs
{
public static class XLuaConfigUtil
{
	public static bool hasGenericParameter(Type type)
	{
		if (type.IsGenericTypeDefinition) return true;
		if (type.IsGenericParameter) return true;
		if (type.IsByRef || type.IsArray)
		{
			return hasGenericParameter(type.GetElementType());
		}
		if (type.IsGenericType)
		{
			foreach (var typeArg in type.GetGenericArguments())
			{
				if (hasGenericParameter(typeArg))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool typeHasEditorRef(Type type)
	{
		if (type.Namespace != null && (type.Namespace == "UnityEditor" || type.Namespace.StartsWith("UnityEditor.")))
		{
			return true;
		}
		if (type.IsNested)
		{
			return typeHasEditorRef(type.DeclaringType);
		}
		if (type.IsByRef || type.IsArray)
		{
			return typeHasEditorRef(type.GetElementType());
		}
		if (type.IsGenericType)
		{
			foreach (var typeArg in type.GetGenericArguments())
			{
				if (typeArg.IsGenericParameter)
				{
					//skip unsigned type parameter
					continue;
				}
				if (typeHasEditorRef(typeArg))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool delegateHasEditorRef(Type delegateType)
	{
		if (typeHasEditorRef(delegateType)) return true;
		var method = delegateType.GetMethod("Invoke");
		if (method == null)
		{
			return false;
		}
		if (typeHasEditorRef(method.ReturnType)) return true;
		return method.GetParameters().Any(pinfo => typeHasEditorRef(pinfo.ParameterType));
	}
}
}