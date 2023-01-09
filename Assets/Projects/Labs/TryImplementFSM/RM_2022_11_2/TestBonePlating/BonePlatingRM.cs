using System;
using UnityEngine;
using static Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM.MyEntryData.EntryType;
using static Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM.UsageStateType;
namespace Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating
{
	public class BonePlatingRM : RuleMachine<BonePlatingRM.MyEntryData>
	{
		public class MyEntryData
		{
			public enum EntryType
			{
				MachineUpdate,
				AfterDamaged
			}
			public EntryType Type;
		}

		public enum UsageStateType
		{
			Ready,
			Activated,
			Cooling
		}

	#region Data

		public Resource PlateCount;
		public TimeStamp ActivatedStamp;
		public TimeStamp CooldownStamp;
		public float ActivatedDuration;
		public float CooldownDuration;
		public State<UsageStateType> UsageState;

	#endregion

	#region Rules

		void OnActivate()
		{
			if (UsageState.Current == Ready
				&& CurEntryParam.Type == AfterDamaged)
			{
				UsageState.Next = Activated;
			}
		}

		void OnDamaged()
		{
			if (UsageState.Current == Activated
				&& CurEntryParam.Type == AfterDamaged)
			{
				PlateCount.Cur--;
				if (PlateCount.Cur == 0)
				{
					UsageState.Next = Cooling;
				}
			}
		}

		void OnActivating()
		{
			if (UsageState.Current == Activated
				&& CurEntryParam.Type == MachineUpdate)
			{
				if (ActivatedStamp.TimeUp(Time.time, ActivatedDuration))
				{
					UsageState.Next = Cooling;
				}
			}
		}

		void OnCooling()
		{
			if (UsageState.Current == Cooling
				&& CurEntryParam.Type == MachineUpdate)
			{
				if (CooldownStamp.TimeUp(Time.time, CooldownDuration))
				{
					UsageState.Next = Ready;
				}
			}
		}

		void OnTransitUsageState()
		{
			if (CurEntryParam.Type == MachineUpdate)
			{
				UsageState.TransitState(out _);
			}
		}

	#endregion

	#region RMConfig

		protected override Action[] CreateRules()
		{
			return new Action[]
			{
				OnActivate,
				OnDamaged,
				OnActivating,
				OnCooling,
				OnTransitUsageState
			};
		}

	#endregion

	#region Factory

		public BonePlatingRM()
		{
			PlateCount = new(3, 3);
			ActivatedDuration = 3;
			CooldownDuration = 15;
			ActivatedStamp = new();
			CooldownStamp = new();
			UsageState = new(Ready, new()
			{
				{ (Ready, Activated), () => { ActivatedStamp.Value = Time.time; } },
				{ (Activated, Cooling), () => { CooldownStamp.Value = Time.time; } },
				{ (Cooling, Ready), () => { PlateCount.Fill(); } }
			});
		}

	#endregion

	}

}