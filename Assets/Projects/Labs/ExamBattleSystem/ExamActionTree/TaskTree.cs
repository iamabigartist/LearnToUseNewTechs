using System.Collections.Generic;
using static Labs.ExamBattleSystem.ExamActionTree.TaskNode;
namespace Labs.ExamBattleSystem.ExamActionTree
{
	public class TaskTree
	{
		List<TaskNode> procedure_list;
		public void AddNode(Procedure procedure, TaskNode[] before_nodes, TaskNode[] after_nodes)
		{
			var cur_node = new TaskNode(procedure);
			foreach (var before_node in before_nodes) { SetOrder(before_node, cur_node); }
			foreach (var after_node in after_nodes) { SetOrder(cur_node, after_node); }
			procedure_list.Add(cur_node);
		}
	}
}