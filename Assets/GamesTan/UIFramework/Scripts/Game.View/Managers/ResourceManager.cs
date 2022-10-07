using System.Collections.Generic;
using System.IO;
using GamesTan.Data;

using UnityEngine;
using Object = UnityEngine.Object;

namespace GamesTan {

    [System.Serializable]
    public partial class ResourceManager : BaseManager<ResourceManager> {
        private AssetConfig _gameConfig => AssetConfig.Instance;

        private Dictionary<int, Object> _id2Prefab = new Dictionary<int, Object>();

        
        public T Instantiate<T>(int assetId, Transform parent = null) where T : Component {
            return Instantiate<T>(assetId, Vector3.zero, Quaternion.identity, parent);
        }
        public GameObject Instantiate(int assetId) {
            return Instantiate(assetId, Vector3.zero, Quaternion.identity, null);
        }

        public GameObject Instantiate(int assetId, Transform parent) {
            return Instantiate(assetId, Vector3.zero, Quaternion.identity, parent);
        }

        public T Instantiate<T>(int assetId, Vector3 pos, Quaternion rot, Transform parent) where T : Component {
            var go = Instantiate(assetId, pos, rot, parent);
            var view = go.GetOrAddComponent<T>();
            return view;
        }

        public GameObject Instantiate(int assetId, Transform parent, Vector3 localPos, Vector3 localScale) {
            var go = Instantiate(assetId, Vector3.zero, Quaternion.identity, parent);
            if (go == null) return null;
            go.transform.localPosition = localPos;
            go.transform.localScale = localScale;
            return go;
        }

        public GameObject Instantiate(int assetId, Vector3 pos, Quaternion rot, Transform parent = null,
            bool isDepartObj = false) {
            var fab = LoadPrefab(assetId);
            if (fab == null) return null;
            GameObject go = null;
            if (isDepartObj) {
                go = Object.Instantiate(fab, pos, rot, parent);
            } else {
                go = EditorExtUtil.Instantiate(fab, pos, rot, parent);
            }

            return go;
        }


        public GameObject LoadPrefab(int assetId) { return LoadAsset<GameObject>(assetId); }

        public T LoadConfig<T>(int assetId) where T : ScriptableObject {
            return _gameConfig.GetConfig(assetId) as T;
        }

        public T LoadAsset<T>(int assetId) where T : Object {
            if (Application.isPlaying) {
                if (_id2Prefab.TryGetValue(assetId, out var prefab)) {
                    return prefab as T;
                }
            }

            var path = _gameConfig.GetPath(assetId);
            if (path != null) {
                var fab = AssetsUtil.LoadUObject<T>(path);
                Debug.Assert(fab != null, " LoadAsset error: " + path);
                _id2Prefab[assetId] = fab;
                return fab;
            }

            Debug.LogError("Asset not exist " + assetId);
            return null;
        }
    }
}