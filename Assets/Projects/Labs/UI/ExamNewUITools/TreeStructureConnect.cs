using System;
using System.Collections.Generic;
using UnityEngine.UIElements;
namespace Labs.UI.ExamNewUITools
{
public static class TreeStructureConnect<TEnum, TNodeObject> where TEnum : Enum
{
	public struct Node
	{
		public TNodeObject obj;
		public List<Node> children_list;
		public Node(TNodeObject obj, List<Node> children_list = null)
		{
			this.obj = obj;
			this.children_list = children_list;
		}
	}
	public delegate void ConnectDlgt(TNodeObject parent, TNodeObject child);
	public static void TreeConnect(Node root, Dictionary<TEnum, ConnectDlgt> connect_methods)
	{
		
	}
}


public static class VEConnector
{
	// public class Connector : TreeStructureConnect<VisualElement>
	// {
	// 	public Connector() => connect_method = (parent, child) => parent.Add(child);
	// }
	// static Connector connector = new();
	// public static void Connect(this VisualElement root, params TreeStructureConnect<,>.Node[] nodes) {}
}

public static class Test1
{
	static void A() {}
}
}