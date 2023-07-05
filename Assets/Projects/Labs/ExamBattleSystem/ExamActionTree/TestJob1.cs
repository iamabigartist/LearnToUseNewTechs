using Unity.Jobs;
using UnityEngine;
namespace Labs.ExamBattleSystem.ExamActionTree
{

	public class MyContainer<T>
	{
		public MyContainer<MyContainer<T>> another;
		public T data;
	}
	public unsafe class TestJob1 : MonoBehaviour
	{
		void Start()
		{
			var b = new TestDestination();
			var job = new Job1() { destination = &b };
			job.Schedule().Complete();
			Debug.Log(b.a);
		}
	}
}