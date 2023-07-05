using Unity.Collections;
namespace Labs.ExamBattleSystem.ExamActionTree
{
	[PolymorphicStruct]
	public interface IProcedure
	{
		public void Execute();
	}
	public partial struct Procedure {}
}