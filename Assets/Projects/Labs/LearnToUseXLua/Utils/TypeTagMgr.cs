using System;
using UnityEditor;
using UnityEngine;
namespace Labs.LearnToUseXLua.Utils
{

//管理几个过程，
//动态收集所有标签类型

public class TypeTagMgr
{


	static TypeTagMgr instance;

	[InitializeOnLoadMethod]
	static void Test1()
	{
		instance = new();
		instance.Init();
	}

	public void Init()
	{
		AppDomain.CurrentDomain.AssemblyLoad += OnAssemblyLoad;

	}

	void OnAssemblyLoad(object sender, AssemblyLoadEventArgs args)
	{
		Debug.Log($"AssemblyLoadEventHandler: {args.LoadedAssembly.FullName}");
	}

	public void Terminate()
	{
		AppDomain.CurrentDomain.AssemblyLoad -= OnAssemblyLoad;

	}

}

}