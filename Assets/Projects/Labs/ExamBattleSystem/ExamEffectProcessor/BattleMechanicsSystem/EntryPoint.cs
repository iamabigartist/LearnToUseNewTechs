using System.Collections.Generic;
namespace Labs.ExamEffectProcessor.BattleMechanicsSystem
{
	public interface IEntryPoint
	{
		void ExecuteSequential();
	}

	public struct EntryPoint<TData, TResult> : IEntryPoint
		where TResult : IRequest<TResult>, new()
	{
		public IEnterable<TData, TResult>.IEntry entry;
		public TData enter_data;
		public EntryPoint(
			IEnterable<TData, TResult>.IEntry entry,
			TData enter_data)
		{
			this.entry = entry;
			this.enter_data = enter_data;
		}

		public void ExecuteSequential()
		{
			var exit_request = new List<TResult>();
			foreach (var enterable in entry.Enterables())
			{
				var cur_exit_request = enterable.Enter(enter_data);
				exit_request.Add(cur_exit_request);
			}
			foreach (var request in exit_request)
			{
				request.Execute();
			}

		}
	}
}