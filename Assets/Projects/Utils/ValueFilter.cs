using System.Collections.Generic;
using System.Linq;
namespace Utils
{
	/// <summary>
	///     <para>Filter represents all the value of a variable that indicate ture state.</para>
	///     <para>No value means any value is matched.</para>
	/// </summary>
	public class ValueFilter<T>
	{
		public HashSet<T> Set;
		public ValueFilter(params T[] values) { Set = values.ToHashSet(); }
		public bool Match(T value) => Set.Count == 0 || Set.Contains(value);
	}
}