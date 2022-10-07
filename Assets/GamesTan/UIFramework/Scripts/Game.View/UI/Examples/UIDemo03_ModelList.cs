using System;
using System.Collections;
using System.Collections.Generic;
using GamesTan.Data;
using UnityEngine;

namespace GamesTan.UI {
    // Model
    public class UIDemo03_ModelList : UIDemo02_PureModel, IItemListWindow {
        private GameObject UIPanelItemListDemo03 => GetRef<GameObject>("UIPanelItemListDemo03");
        public override void DoAwake() {
            UIDataModelData.CurData = GameData.Instance.Heroes[0];
            base.DoAwake();
        }
        public void OnClickItem(UIItem item) {
            ShowHero(item.Data);
        }
    }
    
    public class UIPanelItemListDemo03 : UIPanelItemListDemo01 {
        public override void OnClickItem(UIItem item) {
            base.OnClickItem(item);
            var id = UIDataModelData.CurData?.EntityId ?? 0;
            foreach (var cell in _scrollRect.AllCells) {
                var testItem = cell.Item.GetOrAddComponent<UIItem>();
                testItem.Toggle(IsCellOn(testItem.Data));
            }
        }  
        protected override bool IsCellOn(BaseItemData data) {
            var id = UIDataModelData.CurData?.EntityId ?? 0;
            return data.EntityId == id;
        }
    }
}