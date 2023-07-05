namespace Labs.ExamBattleSystem.ExamActionTree
{
	public interface IProvider
	{
		void GetProcedure(TaskTree tree, ITiming timing);
	}
}