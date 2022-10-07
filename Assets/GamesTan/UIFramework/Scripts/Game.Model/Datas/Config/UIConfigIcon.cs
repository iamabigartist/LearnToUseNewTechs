using System.Collections.Generic;
using GamesTan.Data;
using UnityEngine;

using Sirenix.OdinInspector;

namespace GamesTan {

    public abstract class UIConfigIcon : BaseGlobalConfig<UIConfigIcon> {
        public string SearchRootDir => GlobalProjectConfig.Instance.RawResDir;
        public List<string> SearchDirs = new List<string>() {
            "UI/Equip",
            "UI/Items", 
            "UI/Player",
            "UI/Button",
            "UI/Items",
            "UI/RoleIcon"
        };
        
        [System.Serializable]
        public class ClassInfo {
            [LabelText("图标框")] public Sprite Frame;
            [LabelText("背景色")] public Color Bg;
            [LabelText("字体色")] public Color Color;
            
        }

        public const string NullEquipKey = "NullEquip";
        public const string NullSkillKey = "NullSkill";
        [System.Serializable]
        public class Info {
            public string Name = "";
            public Sprite Icon;
        }
        [Header("Infos")]
        [TableList(ShowIndexLabels = true)] public List<Info> Infos = new List<Info>();
        protected Dictionary<string, Sprite> _name2Icons = new Dictionary<string, Sprite>();

        [LabelText("品阶信息")] [TableList]public List<ClassInfo> ClassInfos = new List<ClassInfo>();

        public static ClassInfo GetInfo(int grade) {
            if (grade < 0) return Instance. ClassInfos[0];
            if (grade >= (int)EGrade.White) return Instance.ClassInfos[(int)EGrade.White];
            return Instance. ClassInfos[grade];
        }

        public static Color GetGradeBg(int grade) => GetInfo(grade).Bg;

        public static Sprite GetSprite(long id) {
            if (Instance._name2Icons.TryGetValue(id.ToString(), out var icon)) return icon;
            return null;
        }

        public override void DoInit() {
            _name2Icons.Clear();
            foreach (var info in Infos) {
                if (_name2Icons.ContainsKey(info.Name)) {
                    Debug.LogError("Duplicate icon name " + info.Name);
                }

                _name2Icons[info.Name] = info.Icon;
            }
        }

    }
}