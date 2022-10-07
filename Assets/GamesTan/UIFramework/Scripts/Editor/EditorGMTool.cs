using System;
using GamesTan.Data;
using UnityEditor;
using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace GamesTan {
    [CustomEditor(typeof(MonoAssetConfig))]
    public class EditorGMTools : EditorWindow {

        private static EditorGMTools _instance;
        [MenuItem("Tools/GMTools")]
        public static void ShowWindow() {
            var window = (EditorGMTools) EditorWindow.GetWindow(typeof(EditorGMTools), false, "Editor");
            _instance = (EditorGMTools) window;
        }
        private void OnGUI() {
            DrawMoney();
        }
        
        private void DrawMoney() {
            GUILayout.Space(10);
            GUILayout.BeginHorizontal();
            DrawButton("+1W Coin", () => {
                GameData.Instance.Coin += 10000;
            });
            DrawButton("+1W Diamond", () => {
                GameData.Instance.Diamond +=  10000;
            });
            DrawButton("+1W Power", () => {
                GameData.Instance.Dirty +=  10000;
            });
            GUILayout.EndHorizontal();
        }  
        void DrawButton(string name, Action callBack) {
            if (GUILayout.Button(name)) {
                callBack();
            }
        }

    }
}