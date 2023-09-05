using System.Collections.Generic;
using System.Linq;
namespace Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree
{
public class CategoryPath
{
	List<string> nodes;
	public CategoryPath(params string[] nodes) { this.nodes = nodes.ToList(); }
	public override string ToString() => string.Join(".", nodes);
	public override int GetHashCode() => ToString().GetHashCode();
	public override bool Equals(object o)
	{
		if (o is CategoryPath path_b) { return ToString() == path_b.ToString(); }
		return false;
	}
	public bool IsValidIn(CategoryNode tree_root)
	{
		var cur_parent_node = tree_root;
		foreach (var node in nodes)
		{
			if (!cur_parent_node.children_category_dict.
				TryGetValue(node, out cur_parent_node)) { return false; }
		}
		return true;
	}
}
}