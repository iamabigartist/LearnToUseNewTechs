using System.Collections;
using System.Collections.Generic;
using GamesTan.Data;
using UnityEngine;
using UnityEngine.UI;

namespace GamesTan.UI {
    public class UIDemo01_PureList : UIBaseWindow , IItemListWindow {
        private Button BtnClose => GetRef<Button>("BtnClose");
        private GameObject UIPanelItemListDemo01 => GetRef<GameObject>("UIPanelItemListDemo01");
     
        public void OnClickItem(UIItem item) {
            UIDataModelData.CurData = item.Data;
            OpenAndClose(UIDefine.UIDemo02_PureModel);
        }
    }
    
    public class UIPanelItemListDemo01 : UIPanelItemList<UIItem> {
        protected override List<BaseItemData> SetupData() {
            var items = GameData.Instance.Heroes;
            foreach (var item in items) {
                item.__TempData = item.Id + item.Grade * 1000000;
            }
            items.Sort((a, b) => (b.__TempData - a.__TempData).ToCompareInt());
            return items;
        }
    }
}