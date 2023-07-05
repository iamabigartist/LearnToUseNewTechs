using System.Collections.Generic;
namespace Labs.ExamEffectProcessor.BattleMechanicsSystem
{
	public interface IEntryData {}

	public class EntryManager
	{
		public readonly LinkedList<IEntryPoint> entry_request_list;
		public EntryManager(LinkedList<IEntryPoint> entry_request_list)
		{
			this.entry_request_list = entry_request_list;
		}
		public void ExecuteFrame()
		{
			while (entry_request_list.Count > 0)
			{
				var cur_request = entry_request_list.First;
				entry_request_list.RemoveFirst();
				cur_request.Value.ExecuteSequential();
			}
		}
	}
}