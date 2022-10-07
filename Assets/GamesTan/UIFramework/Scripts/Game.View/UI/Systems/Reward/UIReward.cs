using System.Collections;
using System.Collections.Generic;
using GamesTan.Data;
using UnityEngine;
using UnityEngine.UI;

namespace GamesTan.UI {
    public class UIPanelItemListReward : UIPanelItemList<UIItem>  {
        protected override List<BaseItemData> SetupData() {
            var items = RewardDatas.ItemDatas;
            foreach (var item in items) {
                item.__TempData =  item.Id;
            }
            items.Sort((a,b)=>(b.__TempData - a.__TempData).ToCompareInt());
            return items;
        }
    }

    public class UIReward : UIBaseWindow {
        private Button BtnClose => GetRef<Button>("BtnClose");
        private Button BtnSure => GetRef<Button>("BtnSure");
        private GameObject UIPanelItemListReward => GetRef<GameObject>("UIPanelItemListReward");
        protected override void OnClick_BtnClose() {
            Close();
        }
        
        public void OnClick_BtnSure() {
            Close();
        }
    }
}