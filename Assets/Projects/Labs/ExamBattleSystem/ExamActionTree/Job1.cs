using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
namespace Labs.ExamBattleSystem.ExamActionTree
{
	
	
	public struct TestDestination
	{
		public int a;
	}

	[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
	public unsafe struct Job1 : IJob
	{
		[NativeDisableUnsafePtrRestriction]
		public TestDestination* destination;
		public void Execute()
		{
			destination->a = 100;
		}
	}

}