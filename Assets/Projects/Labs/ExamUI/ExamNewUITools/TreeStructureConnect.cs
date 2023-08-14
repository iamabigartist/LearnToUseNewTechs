using System.Collections.Generic;
using System.Linq;
namespace Labs.ExamUI.ExamNewUITools
{
public static class TreeStructureConnect<TNodeObject>
{
	public struct Node
	{
		public TNodeObject obj;
		public List<Node> children_list;
		public bool is_leaf_node => children_list == null;
		public Node(TNodeObject obj, params Node[] children_list)
		{
			this.obj = obj;
			this.children_list = children_list?.ToList();
		}
		public static implicit operator Node((TNodeObject obj, Node[] children) p) => new(p.obj, p.children);
	}
	public delegate void ConnectDlgt(TNodeObject parent, TNodeObject child);
	public static void TreeConnect(ConnectDlgt connect_method, Node root)
	{
		Stack<Node> stack = new Stack<Node>();
		stack.Push(root);
		while (stack.TryPop(out var node))
		{
			if (node.is_leaf_node) { continue; }
			foreach (var child in node.children_list)
			{
				connect_method(node.obj, child.obj);
				stack.Push(child);
			}
		}
	}
}
}