using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GamesTan.UI;
using UnityEditor;

namespace GamesTan.EditorExt {
    [CustomEditor(typeof(MonoReferenceHolder))]
    public class EditorMonoReferenceHolder : EditorReferenceHolder {
        protected override void OnShowInspectorGUI() {
            string errorMsg = "";
        }
    }
}