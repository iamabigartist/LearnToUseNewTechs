using System;
using System.Collections.Generic;
namespace Labs.ExamUI.ExamNewUITools
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
	public static void TreeConnect(Node root, Dictionary<TEnum, ConnectDlgt> connect_methods) {}
}
}