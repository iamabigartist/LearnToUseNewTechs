using System.Collections.Generic;
namespace Labs.ExamBattleSystem.ExamActionTree
{
	public class TaskNode
	{
		public static void SetOrder(TaskNode node_before, TaskNode node_after)
		{
			node_before.next_nodes.Add(node_after);
			node_after.prev_nodes.Add(node_before);
		}
		public List<TaskNode> prev_nodes;
		public List<TaskNode> next_nodes;
		public Procedure cur_procedure;
		public TaskNode(Procedure cur_procedure)
		{
			prev_nodes = new();
			next_nodes = new();
			this.cur_procedure = cur_procedure;
		}
	}
}