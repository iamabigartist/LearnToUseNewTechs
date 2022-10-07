
using UnityEngine;

namespace GamesTan.UI {
    public class UIManager : BaseUIManager {
        public int UIClickSoundId;
        public int UIHoverSoundId;
        
        public override void DoAwake() {
            base.DoAwake();
            //IsShowLog = true;
            RegisterAssembly(typeof(UIManager).Assembly);
            var config = ResourceManager.Instance.LoadConfig<ScriptableObject>(8000);
            
            // Load prefab then instantiate it
            var prefab = ResourceManager.Instance.LoadPrefab(31201);
            var goFab = GameObject.Instantiate(prefab);
            
            // Instantiate Prefab directly
            var go = ResourceManager.Instance.Instantiate(31201);
        }

        public override void DoStart() {
            //Debug.Log("UIManager Start");
            UICanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
            UICamera = GameObject.Find("UICamera").GetComponent<Camera>();

            ToggleUIEffectMode(false);
            var prefab = AssetsUtil.LoadPrefab(_prefabDir + UIDefine.UIRoot.ResDir);
            if (prefab == null) {
                Debug.LogError("Can not load UIRoot !" + UIDefine.UIRoot.ResDir);
            }

            var uiGo = GameObject.Instantiate(prefab, UICanvas.transform);
            var refHolder = uiGo.GetComponent<IReferenceHolder>();
            if (refHolder == null) {
                Debug.LogError("UIManager RefHolder null");
            }

            normalParent = refHolder.GetRef<Transform>("TransNormal");
            forwardParent = refHolder.GetRef<Transform>("TransForward");
            importParent = refHolder.GetRef<Transform>("TransNotice");
            //Debug.Log("UIStart ");

            OpenWindow(UIDefine.UIMainMenu);
            BasePressedScale.OnEventPointClick = ()=> AudioManager.PlayAudio(UIClickSoundId);
            BasePressedScale.OnEventPointerEnter = ()=> AudioManager.PlayAudio(UIHoverSoundId);
        }

        protected override void OnCloseWindow(UIBaseWindow window) {
            if (window.ResPath != UIDefine.UIMainMenu.ResDir) {
                bool hasActive = false;
                foreach (var win in openedWindows) {
                    if (win != null && win.gameObject.activeSelf) {
                        hasActive = true;
                    }
                }

                if (!hasActive) {
                    OpenWindow(UIDefine.UIMainMenu);
                }
            }
        }
    }
}