using UnityEngine;
using static Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM.MyEntryData.EntryType;
using static Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM.MyObjectData.UsageStateType;
namespace Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating
{
	public class BonePlatingRM : RuleMachine<BonePlatingRM.MyObjectData, BonePlatingRM.MyEntryData>
	{
		public class MyObjectData
		{
			public enum UsageStateType
			{
				Ready,
				Activated,
				Cooling
			}
			public Resource PlateCount;
			public Duration ActivatedDuration;
			public Duration CooldownDuration;
			public State<UsageStateType> UsageState;
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

		protected BonePlatingRM(MyObjectData Data, Rule[] Rules) : base(Data, Rules) {}

		public static BonePlatingRM Create()
		{
			BonePlatingRM rm = new(
				new()
				{
					PlateCount = new(3, 3),
				},
				new Rule[]
				{
					new("Activate", (Data, EntryData) =>
					{
						if (Data.UsageState.Current == Ready
							&& EntryData.Type == AfterDamaged)
						{
							Data.UsageState.Next = Activated;
						}
					}),
					new("Damaged", (Data, EntryData) =>
					{
						if (Data.UsageState.Current == Activated
							&& EntryData.Type == AfterDamaged)
						{
							Data.PlateCount.Cur--;
							if (Data.PlateCount.Cur == 0)
							{
								Data.UsageState.Next = Cooling;
							}
						}
					}),
					new("Activating", (Data, EntryData) =>
					{
						if (Data.UsageState.Current == Activated
							&& EntryData.Type == MachineUpdate)
						{
							if (Data.ActivatedDuration.TimeUp(Time.time))
							{
								Data.UsageState.Next = Cooling;
							}
						}
					}),
					new("Cooling", (Data, EntryData) =>
					{
						if (Data.UsageState.Current == Cooling
							&& EntryData.Type == MachineUpdate)
						{
							if (Data.CooldownDuration.TimeUp(Time.time))
							{
								Data.UsageState.Next = Ready;
							}
						}
					}),
					new("UsageStateTransition", (Data, Param) =>
					{
						if (Param.Type == MachineUpdate)
						{
							Data.UsageState.TransitState(out _);
						}
					})
				}
				);


			rm.Data.UsageState = new(Ready, new()
			{
				{ (Ready, Activated), () => { rm.Data.ActivatedDuration.Stamp = Time.time; } },
				{ (Activated, Cooling), () => { rm.Data.CooldownDuration.Stamp = Time.time; } },
				{ (Cooling, Ready), () => { rm.Data.PlateCount.Fill(); } }
			});


			return rm;
		}
	}

}