using UnityEditor;
using UnityEngine;

namespace GamesTan {
#if !ODIN_INSPECTOR
    [CustomEditor(typeof(MonoUIConfigIcon))]
#endif
    public class EditorMonoUIConfigIcon : Editor {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            if (GUILayout.Button("DoInit")) {
                (target as MonoUIConfigIcon).DoInit();
            }
        }
    }
}