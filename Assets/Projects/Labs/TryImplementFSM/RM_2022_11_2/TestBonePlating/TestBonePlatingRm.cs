using System;
using UnityEngine;
using YamlDotNet.Serialization;
using static Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM.MyEntryData.EntryType;
using static Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM.MyObjectData.UsageStateType;
namespace Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating
{

	public class TestBonePlatingRm : MonoBehaviour
	{
		ISerializer serializer;
		BonePlatingRM bone_plating_rm;
		double cur_remain_time;
		void Start()
		{
			serializer = new SerializerBuilder().
				WithIndentedSequences().
				Build();
			bone_plating_rm = BonePlatingRM.Create();
		}

		void Update()
		{
			bone_plating_rm.Run(new() { Type = MachineUpdate });
			var data = bone_plating_rm.Data;
			cur_remain_time = data.UsageState.Current switch
			{
				Ready => 0,
				Activated => data.ActivatedStamp.RemainTime(Time.time, data.ActivatedDuration),
				Cooling => data.CooldownStamp.RemainTime(Time.time, data.CooldownDuration),
				_ => throw new ArgumentOutOfRangeException()
			};
		}

		void OnGUI()
		{
			GUI.enabled = bone_plating_rm.Data.UsageState.Current != Cooling;
			if (GUILayout.Button("Damage")) { bone_plating_rm.Run(new() { Type = AfterDamaged }); }
			GUI.enabled = true;
			var box_style = GUI.skin.box;
			box_style.alignment = TextAnchor.UpperLeft;
			GUILayout.Box(serializer.Serialize(bone_plating_rm.Data), box_style);
			GUILayout.Box($"remain_time: {cur_remain_time}");

		}
	}
}