using GamesTan.Data;
using UnityEngine;
using UnityEngine.UI;

namespace GamesTan.UI {
    public class UIDemo02_PureModel : UIBaseWindow {
        
        protected Button BtnClose => GetRef<Button>("BtnClose");
        protected RawImage RawImageUIModel => GetRef<RawImage>("RawImageUIModel");
        protected UIModel _uiModel;

        public override void DoAwake() {
            base.DoAwake();
            _uiModel = UIModel.CreateInstance<UIModel>(new Vector2Int(540, 960),
                GameDefine.UIModelPrefabDir + "UIModelDemo",
                transform);
            RawImageUIModel.texture = _uiModel.RenderTexture;
            ShowHero(UIDataModelData.CurData);
        }

        public override void OnClose() {
            base.OnClose();
            _uiModel?.DoDestroy();
        }

        protected void ShowHero(BaseItemData hero) {
            UIDataModelData.CurData = hero;
            var obj = ResourceManager.Instance.Instantiate((int)hero.Id);
            _uiModel.SetModel(obj);
        }

    }
}