using System;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;

public static class ExamBuildLambda
{
	public class Example
	{
		public int Field111;
		public string Field222;
	}

	
	[MenuItem("Labs/BuildLambda")]
	public static void Run()
	{
		var example = new Example();
        
		// 使用字段路径生成委托
		var (getter, setter) = CreateFieldAccessors<Example>("Field111");

		// 设置字段值
		setter(example, 100);
		Debug.Log(getter(example)); // 输出 100
        
		// 对于另一个字段
		var (getter2, setter2) = CreateFieldAccessors<Example>("Field222");
        
		// 设置字符串字段值
		setter2(example, "Hello");
		Debug.Log(getter2(example)); // 输出 Hello
	}

	public static (Func<T, object>, Action<T, object>) CreateFieldAccessors<T>(string fieldName)
	{
		var type = typeof(T);
		var field = type.GetField(fieldName);
		if (field == null)
			throw new ArgumentException($"Field '{fieldName}' not found in type '{type.FullName}'.");

		// 生成 getter
		var param = Expression.Parameter(type, "x");
		var fieldAccess = Expression.Field(param, field);
		var getter = Expression.Lambda<Func<T, object>>(Expression.Convert(fieldAccess, typeof(object)), param).Compile();

		// 生成 setter
		var valueParam = Expression.Parameter(typeof(object), "value");
		var setterBody = Expression.Assign(fieldAccess, Expression.Convert(valueParam, field.FieldType));
		var setter = Expression.Lambda<Action<T, object>>(setterBody, param, valueParam).Compile();

		return (getter, setter);
	}
}