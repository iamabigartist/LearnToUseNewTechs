namespace Labs.ExamBattleSystem.ExamActionTree
{
	public interface ITiming {}

	public struct TimingOne : ITiming
	{
		TaskNode timing_task_node;
	}
}