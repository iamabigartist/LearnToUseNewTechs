using GamesTan.UI;
using UnityEditor;
using UnityEngine;

namespace GamesTan.EditorExt {
    [CustomEditor(typeof(BaseSuperScrollRect), true)]
    [CanEditMultipleObjects]
    public class EditorSuperScrollRect : Editor {
        public override void OnInspectorGUI() {
            var owner = target as BaseSuperScrollRect;
            serializedObject.Update();

            PropertyField("m_Viewport");
            PropertyField("m_Content");
            PropertyField("CellPrefab");
            GUILayout.Space(5);
            PropertyField("Direction");
            PropertyField("IsGrid");
            if (owner.IsGrid) {
                PropertyField("Segment");
            }

            EditorGUI.BeginChangeCheck();
            PropertyField("Padding");
            PropertyField("Spacing");
            if (EditorGUI.EndChangeCheck()) {
                owner.ReloadData();
            }
            
            DrawInternalProperties();
            serializedObject.ApplyModifiedProperties();

        }

        private void DrawInternalProperties() {
            EditorGUILayout.Space();
            PropertyField("m_MovementType");
            PropertyField("m_Elasticity");
            PropertyField("m_Inertia");
            PropertyField("m_DecelerationRate");
            PropertyField("m_ScrollSensitivity");
            EditorGUILayout.Space();
            PropertyField("m_OnValueChanged");
        }

        void PropertyField(string name) {
            var prop = serializedObject.FindProperty(name);
            EditorGUILayout.PropertyField(prop);
        }

    }
}