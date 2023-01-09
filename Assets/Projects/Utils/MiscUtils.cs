using System;
namespace Utils
{
	public static class MiscUtils
	{
		public static void CompareAndUpdate<T>(ref T destination, T value, Func<T, T, bool> comparer,out bool changed)
		{
			changed = !comparer(destination, value);
			if (changed) { destination = value; }
		}
	}
}