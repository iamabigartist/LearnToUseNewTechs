using UnityEditor;
using UnityEngine;

namespace GamesTan.EditorExt {
#if !ODIN_INSPECTOR
    [CustomEditor(typeof(MonoAssetConfig))]
#endif
    public class EditorMonoAssetConfig : Editor {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            if (GUILayout.Button("InitData")) {
                (target as MonoAssetConfig).InitData();
            }
        }
    }
    
}