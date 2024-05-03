using System;
using System.Collections.Generic;
using UnityEngine.UIElements;
namespace Labs.LearnToUseXLua.TestDynamicWindow.Editor
{
public struct VEScope<T> : IDisposable
	where T : VisualElement
{
	public event Action OnDispose;
	public void Dispose() { OnDispose?.Invoke(); }
}

public class UXMLBuilder
{
	Stack<VisualElement> parent_stack = new();
	public VisualElement cur_parent;

	public UXMLBuilder(VisualElement root_ve)
	{
		PushScope(root_ve);
	}
	
	public void Add<T>(out T ve_var, T ve_new) where T : VisualElement
	{
		ve_var = ve_new;
		cur_parent.Add(ve_new);
	}
	public VEScope<T> Scope<T>(T scope_ve) where T : VisualElement
	{
		PushScope(scope_ve);
		var scope = new VEScope<T>();
		scope.OnDispose += PopScope;
		return scope;
	}
	void PushScope(VisualElement scope_ve)
	{
		parent_stack.Push(cur_parent);
		cur_parent = scope_ve;
	}
	void PopScope()
	{
		if (parent_stack.Count <= 1) { throw new InvalidOperationException("Already at root ve."); }
		cur_parent = parent_stack.Pop();
	}
}
}