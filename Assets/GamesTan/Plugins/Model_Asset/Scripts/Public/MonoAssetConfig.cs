using System;
using System.IO;

using Sirenix.OdinInspector;
using UnityEngine;

namespace GamesTan {
    
    [CreateAssetMenu(menuName = "Cfg/Global/AssetConfig", fileName = "AssetConfig", order = 0)]
    public partial class MonoAssetConfig : AssetConfig {
        [Button]
        public void InitData() {
            DoInit();
            assetInfos.Sort((a, b) => a.id - b.id );
        }

        public override void DoInit() {
#if UNITY_EDITOR
            cfgInfos.Clear();
            PathUtil.Walk(PathUtil.GetFullPath(GlobalProjectConfig.Instance.ResourcesDir + "Configs"), "*.asset", (path) => {
                var strs = Path.GetFileName(path).Split('_');
                try {
                    if (int.TryParse(strs[0], out var id)) {
                        var relPath = PathUtil.GetAssetPath(path);
                        var cfg = UnityEditor.AssetDatabase.LoadAssetAtPath<ScriptableObject>(relPath);
                        cfgInfos.Add(new ConfigInfo() {id = id, config = cfg});
                    }
                }
                catch (Exception e) {
                    Debug.LogError("Config Load failed !" + path + " " + e);
                }
            });

            assetInfos.Clear();
            PathUtil.Walk(PathUtil.GetFullPath(GlobalProjectConfig.Instance.ResourcesDir + "Prefabs"), "*.prefab|*.asset", (path) => {
                var strs = Path.GetFileName(path).Split('_');
                try {
                    if (int.TryParse(strs[0], out var id)) {
                        var relPath = PathUtil.GetAssetPath(path).Replace(GlobalProjectConfig.Instance.ResourcesDir + "", "");
                        string assetName = relPath;
                        assetInfos.Add(new AssetInfo() {id = id, path = assetName});
                    }
                }
                catch (Exception e) {
                    Debug.LogError("Config Load failed " +
                                   "!" + path + " " + e);
                }
            });
            UnityEditor.EditorUtility.SetDirty(this);
#endif
            base.DoInit();
        }
    }
}