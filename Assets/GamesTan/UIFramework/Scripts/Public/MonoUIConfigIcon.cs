using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace GamesTan {
    [CreateAssetMenu(menuName = "Cfg/GlobalUI/UIIconConfig", fileName = "UIIconConfig", order = 0)]
    public partial class MonoUIConfigIcon : UIConfigIcon {
        //[Button]
        public void Clear() {
            Infos.Clear();
        }

        [Button]
        public override void DoInit() {
            Infos.Clear();
            base.DoInit();
#if UNITY_EDITOR
            void AddDir(params string[] relPath) {
                var iconsPath = AssetDatabase.FindAssets("t:Sprite", relPath);
                foreach (var guid in iconsPath) {
                    var path = AssetDatabase.GUIDToAssetPath(guid);
                    var sprite = AssetDatabase.LoadAssetAtPath<Sprite>(path);
                    if (sprite == null) continue;
                    var strs = sprite.name.Split('_');
                    if (strs.Length >= 2 && int.TryParse(strs[0], out var id)) {
                        if (!_name2Icons.ContainsKey(id.ToString())) {
                            Infos.Add(new Info() {Name = id.ToString(), Icon = sprite});
                        }
                    }
                }
            }

            foreach (var dir in SearchDirs) {
                AddDir(SearchRootDir + dir);
            }
            Infos.Sort((a, b) => a.Name.CompareTo(b.Name));
            EditorExtUtil.SetDirty(this);
            base.DoInit();
#endif
        }
    }
}