using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using XLua;
namespace Labs.LearnToUseXLua.xLuaConfigs
{
public static class GenericTypeBlackList
{
	public static List<Type> BlackGenericTypeList = new()
	{
		typeof(Span<>),
		typeof(ReadOnlySpan<>)
	};

	static bool IsBlacklistedGenericType(Type type)
	{
		return type.IsGenericType && BlackGenericTypeList.Contains(type.GetGenericTypeDefinition());
	}

	[BlackList]
	public static Func<MemberInfo, bool> GenericTypeFilter = (memberInfo) =>
	{
		return memberInfo switch
		{
			PropertyInfo propertyInfo => IsBlacklistedGenericType(propertyInfo.PropertyType),
			ConstructorInfo constructorInfo => constructorInfo.GetParameters().Any(p => IsBlacklistedGenericType(p.ParameterType)),
			MethodInfo methodInfo => methodInfo.GetParameters().Any(p => IsBlacklistedGenericType(p.ParameterType)),
			_ => false
		};
	};
}
}