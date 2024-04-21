using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree
{
public static class Test
{
	[MenuItem("Labs/ExamBattleSystem/ExamFullBattleSystem/CategoryTree/TestTreeUsage")]
	public static void TestTreeUsage()
	{
		var tree = new CategoryTreeContainer<List<string>>(new("root", new CategoryNode[]
		{
			new("child1",
				new("child1_1",
					new("child1_1_1"),
					new("child1_1_2")),
				new("child1_2"))
		}));
		tree[new("root", "child1", "child1_1")].Add("dog_jack");
		Debug.Log(tree[new("root", "child1", "child1_1")].Count);
		Debug.Log(tree[new("root", "child1", "child1_1")][0]);
	}
}
}