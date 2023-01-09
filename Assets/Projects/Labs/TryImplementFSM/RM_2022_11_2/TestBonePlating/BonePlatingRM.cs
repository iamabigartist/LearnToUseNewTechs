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
			public TimeStamp ActivatedStamp;
			public TimeStamp CooldownStamp;
			public float ActivatedDuration;
			public float CooldownDuration;
			public State<UsageStateType, ProcessDataDelegate> UsageState;
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
					ActivatedDuration = 3,
					CooldownDuration = 10,
					ActivatedStamp = new(),
					CooldownStamp = new(),
					UsageState = new(Ready, new()
					{
						{ (Ready, Activated), (Data, _) => { Data.ActivatedStamp.Value = Time.time; } },
						{ (Activated, Cooling), (Data, _) => { Data.CooldownStamp.Value = Time.time; } },
						{ (Cooling, Ready), (Data, _) => { Data.PlateCount.Fill(); } }
					})
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
							if (Data.ActivatedStamp.TimeUp(Time.time, Data.ActivatedDuration))
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
							if (Data.CooldownStamp.TimeUp(Time.time, Data.CooldownDuration))
							{
								Data.UsageState.Next = Ready;
							}
						}
					}),
					new("UsageStateTransition", (Data, Param) =>
					{
						if (Param.Type == MachineUpdate)
						{
							if (Data.UsageState.TransitState(out _, out var process))
							{
								process.Invoke(Data, Param);
							}
						}
					})
				}
				);

			return rm;
		}
	}

}