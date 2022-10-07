using System;
using GamesTan.UI;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GamesTan {
    public class GameAssetLoader : IAssetLoader {
        public static bool IsABMode => false;
        public static string RelResDir => GlobalProjectConfig.Instance.ResourcesDir;

        public T LoadUObject<T>(string path, string posfix = "") where T : Object {
            var finalPath = path;
            if (!path.StartsWith("Assets/")) {
                finalPath = RelResDir + path;
                if (!string.IsNullOrEmpty(posfix) && !path.EndsWith(posfix)) {
                    finalPath = finalPath + posfix;
                }
            }
#if UNITY_EDITOR
            if (!IsABMode || !Application.isPlaying) {
                return EditorExtUtil.LoadAssetAtPath<T>(finalPath);
            }
#endif
            // 这里直接使用Unity的 Resource 接口进行加载
            // TODO 使用 AssetBundle 来进行加载
            //var req = Asset.Load(finalPath, typeof(T));

            var idx = path.IndexOf(".", StringComparison.Ordinal);
            if (idx != -1)
                path = path.Substring(0, idx);
            var ret = Resources.Load<T>(path);
            if (ret == null) {
                Debug.LogError($"Can not find Res:{path} = {finalPath}");
            }

            return ret;
        }

        public T LoadAsset<T>(string path) where T : Object {
            return LoadUObject<T>(path, ".asset");
        }

        public string LoadText(string path, string posfix = ".json") {
            var asset = LoadUObject<TextAsset>(path, posfix);
            return asset?.text;
        }

        public GameObject LoadPrefab(string path) {
            return LoadUObject<GameObject>(path, ".prefab");
        }
    }
}