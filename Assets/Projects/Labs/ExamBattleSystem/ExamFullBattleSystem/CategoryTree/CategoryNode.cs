using System.Collections.Generic;
namespace Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree
{
public class CategoryNode
{
	public CategoryNode parent_category;
	public Dictionary<string, CategoryNode> children_category_dict;
	public string category_value;
	public CategoryNode(string category_value, params CategoryNode[] children_category_list)
	{
		this.category_value = category_value;
		children_category_dict = new();
		foreach (var category_node in children_category_list)
		{
			children_category_dict[category_node.category_value] = category_node;
			category_node.parent_category = this;
		}
	}
	public CategoryNode this[string value] => children_category_dict[value];

	public static IEnumerable<string> BFS(CategoryNode root)
	{
		var queue = new Queue<CategoryNode>();
		queue.Enqueue(root);
		while (queue.Count > 0)
		{
			var cur_node = queue.Dequeue();
			yield return cur_node.category_value;
			foreach (var child_node in cur_node.children_category_dict.Values) { queue.Enqueue(child_node); }
		}
	}
}
}