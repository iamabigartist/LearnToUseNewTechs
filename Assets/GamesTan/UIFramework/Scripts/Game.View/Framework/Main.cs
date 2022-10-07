using System;
using System.Collections.Generic;
using System.Reflection;

using UnityEngine;

namespace GamesTan {
    public abstract partial class Main : MonoBehaviour {
        public static Main Instance { get; private set; }

        protected List<IManager> mgrs = new List<IManager>();

        public void Awake() {
            DoAwake();
        }

        public void Start() {
            DoStart();
        }

        public void DoStart() {
            foreach (var mgr in mgrs) {
                mgr.DoStart();
            }
        }

        public void DoAwake() {
            if (Instance != null && Instance != this) {
                GameObject.DestroyImmediate(gameObject);
                return;
            }

            if (Instance == this) return;
            GameObject.DontDestroyOnLoad(gameObject);
            Instance = this;
            AssetsUtil.SetLoader(new GameAssetLoader());

            mgrs.AddRange(GetComponentsInChildren<IManager>());
            RegisterManagers();
            var registerService = new GameEventRegisterService();
            foreach (var mgr in mgrs) {
                registerService.RegisterEvent(mgr);
            }

            foreach (var mgr in mgrs) {
                mgr.DoAwake();
            }
        }

        protected virtual void RegisterManagers() {
            RegisterManagers(typeof(Main).Assembly);
        }

        protected void RegisterManagers(Assembly assembly) {
            var types = assembly.GetTypes();
            var baseType = typeof(BaseManager);
            foreach (var item in types) {
                if (baseType.IsAssignableFrom(item) && !item.IsAbstract) {
                    var flag = BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy;
                    var instanceFunc = item.GetMethod("get_Instance", flag);
                    if (instanceFunc != null) {
                        var obj = instanceFunc.Invoke(null, null);
                        if (obj is IManager instance) mgrs.Add(instance);
                    }
                }
            }
        }

        public void Update() {
            var dt = Time.deltaTime;
            foreach (var mgr in mgrs) {
                mgr.DoUpdate(dt);
            }
        }

        public void FixedUpdate() {
            foreach (var mgr in mgrs) {
                mgr.DoFixedUpdate(Time.fixedDeltaTime);
            }
        }


        public void OnDestroy() {
            foreach (var mgr in mgrs) {
                try {
                    mgr.DoDestroy();
                }
                catch (Exception e) {
                    UnityEngine.Debug.LogError(e);
                }
            }
        }
    }
}