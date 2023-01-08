namespace Labs.TryImplementFSM.RM_2022_11_2
{
	public struct Duration
	{
		public float Stamp;
		public float Interval;
		public Duration(float Interval, float Stamp = 0)
		{
			this.Interval = Interval;
			this.Stamp = Stamp;
		}

		public float RemainTime(float CurTime) { return Stamp + Interval - CurTime; }
		public bool TimeUp(float CurTime) { return Stamp + Interval <= CurTime; }
	}
}