namespace Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating
{
	public struct Resource
	{
		public float Max;
		public float Cur;
		public Resource(float Max, float Cur)
		{
			this.Max = Max;
			this.Cur = Cur;
		}
		public void Fill() { Cur = Max; }
	}
}