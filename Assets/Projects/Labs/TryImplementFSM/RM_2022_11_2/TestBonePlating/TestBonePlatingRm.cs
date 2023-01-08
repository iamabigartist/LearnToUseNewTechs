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
		float cur_remain_time;
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
			cur_remain_time = bone_plating_rm.Data.UsageState.Current switch
			{
				Ready => 0,
				Activated => bone_plating_rm.Data.ActivatedDuration.RemainTime(Time.time),
				Cooling => bone_plating_rm.Data.CooldownDuration.RemainTime(Time.time),
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