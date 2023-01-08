using UnityEngine;
using static Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM.MyEntryData.EntryType;
using static Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM.MyObjectData.BuffState;
namespace Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating
{
	public class BonePlatingRM : RuleMachine<BonePlatingRM.MyObjectData, BonePlatingRM.MyEntryData>
	{
		public class MyObjectData
		{
			public enum BuffState
			{
				Ready,
				Activated,
				Cooling
			}
			public Resource PlateCount;
			public Duration ActivatedDuration;
			public Duration CooldownDuration;
			public BuffState CurBuffState;
			public BuffState NextBuffState;
		}
		public class MyEntryData
		{
			public enum EntryType
			{
				MachineUpdate,
				AfterDamaged
			}
			public EntryType Type;
		}

		protected BonePlatingRM(MyObjectData MachineData, Rule[] Rules) : base(MachineData, Rules) {}
		public static BonePlatingRM Create()
		{
			BonePlatingRM rm = new(
				new()
				{
					PlateCount = new(3, 3),
					ActivatedDuration = new(3),
					CooldownDuration = new(10),
					CurBuffState = Ready
				},
				new Rule[]
				{
					new("Activate", (Data, EntryData) =>
					{
						if (Data.CurBuffState == Ready
							&& EntryData.Type == AfterDamaged)
						{
							Data.NextBuffState = Activated;
						}
					}),
					new("Damaged", (Data, EntryData) =>
					{
						if (Data.CurBuffState == Activated
							&& EntryData.Type == AfterDamaged)
						{
							Data.PlateCount.Cur--;
							if (Data.PlateCount.Cur == 0)
							{
								Data.NextBuffState = Cooling;
							}
						}
					}),
					new("Activating", (Data, EntryData) =>
					{
						if (Data.CurBuffState == Activated
							&& EntryData.Type == MachineUpdate)
						{
							if (Data.ActivatedDuration.TimeUp(Time.time))
							{
								Data.NextBuffState = Cooling;
							}
						}
					}),
					new("Cooling", (Data, EntryData) =>
					{
						if (Data.CurBuffState == Cooling
							&& EntryData.Type == MachineUpdate)
						{
							if (Data.CooldownDuration.TimeUp(Time.time))
							{
								Data.NextBuffState = Ready;
							}
						}
					}),
					new("BuffStateTransition", (Data, Param) =>
					{
						if (Param.Type == MachineUpdate)
						{
							switch (Data.CurBuffState, Data.NextBuffState)
							{
								case (Ready, Activated):
									{
										Data.ActivatedDuration.Stamp = Time.time;
										break;
									}
								case (Activated, Cooling):
									{
										Data.CooldownDuration.Stamp = Time.time;
										break;
									}
								case (Cooling, Ready):
									{
										Data.PlateCount.Fill();
										break;
									}
							}
							Data.CurBuffState = Data.NextBuffState;
						}
					})
				}
				);


			return rm;
		}
	}

}