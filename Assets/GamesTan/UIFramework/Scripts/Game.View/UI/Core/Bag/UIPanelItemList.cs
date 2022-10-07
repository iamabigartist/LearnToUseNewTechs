using System;
using System.Collections;
using System.Collections.Generic;
using GamesTan.Data;
using UnityEngine;

namespace GamesTan.UI {
    public class UIPanelItemList<T> :UIPanelItemList where T : UIItem {        
        public override void SetCell(GameObject cell, int index) {
            var data = _ItemDatas[index] as BaseItemData;
            var item = cell.GetOrAddComponent<T>();
#if UNITY_EDITOR
            item.name = "Cell_" + index;
#endif
            item.DoInit(this,data, index, IsCellOn(data));
        }
    }

    public class UIPanelItemList : UIBasePanel, ISuperScrollRectDataProvider  {
        
        protected Transform TransScrollRect => GetRef<Transform>("TransScrollRect");

        public List<ScrollRectCell> Items => _scrollRect.AllCells;
        protected BaseSuperScrollRect _scrollRect;
        protected IList _ItemDatas;
        protected IItemListWindow _bagWindow => Parent as IItemListWindow;
        protected virtual List<BaseItemData> SetupData() => null;

        public override void DoAwake() {
            base.DoAwake();
            _scrollRect = TransScrollRect.GetComponent<BaseSuperScrollRect>();
            _ItemDatas = SetupData();
            _scrollRect?.DoAwake(this);
        }

        public virtual void OnClickItem(UIItem item) {
            _bagWindow?.OnClickItem(item);
        }

        
        public int GetCellCount() => _ItemDatas.Count;
        
        public virtual void SetCell(GameObject cell, int index) {
        }
        protected virtual bool IsCellOn(BaseItemData data) {
            return false;
        }

    }
}