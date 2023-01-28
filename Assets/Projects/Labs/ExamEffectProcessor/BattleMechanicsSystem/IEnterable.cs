using System.Collections.Generic;
namespace Labs.ExamEffectProcessor.BattleMechanicsSystem
{
	public interface IEnterable<TEnterData, TExitRequest>
		where TExitRequest : IRequest<TExitRequest>, new()
	{
		public interface IEntry
		{
			IEnumerable<IEnterable<TEnterData, TExitRequest>> Enterables();
		}
		TExitRequest Enter(TEnterData data);
	}
}