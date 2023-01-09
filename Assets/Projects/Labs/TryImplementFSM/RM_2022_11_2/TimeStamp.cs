namespace Labs.TryImplementFSM.RM_2022_11_2
{
	public struct TimeStamp
	{
		public double Value;
		public TimeStamp(double InitialValue = 0)
		{
			Value = InitialValue;
		}
		public double RemainTime(double CurTime, double Interval) { return Value + Interval - CurTime; }
		public bool TimeUp(double CurTime, double Interval) { return Value + Interval <= CurTime; }
	}
}