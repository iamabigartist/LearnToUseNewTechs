using System.Collections.Generic;
using UnityEngine;
namespace Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree
{
public class CategoryTreeContainer<TContent>
	where TContent : class, new()
{
	public CategoryNode root;
	public CategoryTreeContainer(CategoryNode root) => this.root = root;
	public Dictionary<CategoryPath, TContent> content_map = new();
	public TContent this[CategoryPath path]
	{
		get
		{
			if (!content_map.ContainsKey(path))
			{
				Debug.Log(string.Join("\n", content_map.Keys));
				content_map.TryAdd(path, new());
			}
			return content_map[path];
		}
	}
}
}