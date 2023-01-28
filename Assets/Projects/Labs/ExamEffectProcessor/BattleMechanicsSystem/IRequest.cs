using System.Collections.Generic;
namespace Labs.ExamEffectProcessor.BattleMechanicsSystem
{
	public interface IRequest<TRequest>
		where TRequest : IRequest<TRequest>, new()
	{

		void Combine(IEnumerable<TRequest> requests);
		void Execute();
		public static TRequest CreateCombine(IEnumerable<TRequest> requests)
		{
			var combined = new TRequest();
			combined.Combine(requests);
			return combined;
		}
	}
}