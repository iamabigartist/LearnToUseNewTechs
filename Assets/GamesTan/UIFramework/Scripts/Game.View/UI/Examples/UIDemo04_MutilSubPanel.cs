using UnityEngine;
using UnityEngine.UI;

namespace GamesTan.UI {
    public class UIDemo04_MutilSubPanel : UIBaseWindow ,IItemListWindow{
        private GameObject UIPanelItemListDemo01 => GetRef<GameObject>("UIPanelItemListDemo01");
        private GameObject UIPanelPlayerMoney => GetRef<GameObject>("UIPanelPlayerMoney");
        
        private Button BtnClose => GetRef<Button>("BtnClose");

        public void OnClickItem(UIItem item) {
            UIDataModelData.CurData = item.Data;
            OpenAndClose(UIDefine.UIDemo02_PureModel);
        }
    }
}