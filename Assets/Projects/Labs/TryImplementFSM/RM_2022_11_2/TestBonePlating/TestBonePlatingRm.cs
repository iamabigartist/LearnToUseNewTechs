using System;
using UnityEngine;
using YamlDotNet.Serialization;
using static Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRm.MyEntryData.EntryType;
using static Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRm.MyObjectData.BuffState;
namespace Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating
{
	public class BonePlatingRm : RuleMachine<BonePlatingRm.MyObjectData, BonePlatingRm.MyEntryData>
	{
		public BonePlatingRm(MyObjectData Data, params Rule[] Rules) : base(Data, Rules) {}
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
		public static BonePlatingRm Create()
		{
			BonePlatingRm rm = new(
				new()
				{
					PlateCount = new(3, 3),
					ActivatedDuration = new(3),
					CooldownDuration = new(10),
					CurBuffState = Ready
				},
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
				}));
			return rm;
		}
	}

	public class TestBonePlatingRm : MonoBehaviour
	{
		ISerializer serializer;
		BonePlatingRm bone_plating_rm;
		float cur_remain_time;
		void Start()
		{
			serializer = new SerializerBuilder().
				WithIndentedSequences().
				Build();
			bone_plating_rm = BonePlatingRm.Create();
		}

		void Update()
		{
			bone_plating_rm.Run(new() { Type = MachineUpdate });
			cur_remain_time = bone_plating_rm.MachineData.CurBuffState switch
			{
				Ready => 0,
				Activated => bone_plating_rm.MachineData.ActivatedDuration.RemainTime(Time.time),
				Cooling => bone_plating_rm.MachineData.CooldownDuration.RemainTime(Time.time),
				_ => throw new ArgumentOutOfRangeException()
			};
		}

		void OnGUI()
		{
			GUI.enabled = bone_plating_rm.MachineData.CurBuffState != Cooling;
			if (GUILayout.Button("Damage")) { bone_plating_rm.Run(new() { Type = AfterDamaged }); }
			GUI.enabled = true;
			var box_style = GUI.skin.box;
			box_style.alignment = TextAnchor.UpperLeft;
			GUILayout.Box(serializer.Serialize(bone_plating_rm.MachineData), box_style);
			GUILayout.Box($"remain_time: {cur_remain_time}");

		}
	}
}