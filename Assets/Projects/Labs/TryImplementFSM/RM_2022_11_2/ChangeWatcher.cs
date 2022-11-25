using System;
namespace Labs.TryImplementFSM.RM_2022_11_2
{
	/// <summary>
	///     观察变量值，在变化时触发事件
	/// </summary>
	public class ChangeWatcher<T>
	{
		public delegate void IsChanged(T oldValue, T newValue);

		T CachedValue;
		Func<T, T, bool> CompareValue;
		Func<T> GetValue;
		IsChanged IsChangedCallback;
		public bool Check()
		{
			T cur_value = GetValue();
			bool changed = CompareValue(cur_value, CachedValue);
			if (changed)
			{
				IsChangedCallback?.Invoke(CachedValue, cur_value);
				CachedValue = cur_value;
			}
			return changed;
		}

		public ChangeWatcher(T InitValue, Func<T, T, bool> CompareValue, Func<T> GetValue, IsChanged IsChangedCallback = null)
		{
			CachedValue = InitValue;
			this.CompareValue = CompareValue;
			this.GetValue = GetValue;
			this.IsChangedCallback = IsChangedCallback;
		}
	}
}