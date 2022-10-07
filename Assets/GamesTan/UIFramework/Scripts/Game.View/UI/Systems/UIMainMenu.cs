using GamesTan.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GamesTan.UI {
    public class UIMainMenu : UIBaseWindow {
        private GameObject UIPanelPlayerMoney => GetRef<GameObject>("UIPanelPlayerMoney");
        private Button BtnPlay => GetRef<Button>("BtnPlay");
        private Button BtnShop => GetRef<Button>("BtnShop");
        private Button BtnHero => GetRef<Button>("BtnHero");
        private Button BtnUpgrade  => GetRef<Button>("BtnUpgrade");
        private Button BtnGuild => GetRef<Button>("BtnGuild");
        private Button BtnInventory => GetRef<Button>("BtnInventory");
        private Button BtnAddDiamond => GetRef<Button>("BtnAddDiamond");
        private Button BtnAddGold => GetRef<Button>("BtnAddGold");
        private Button BtnRanking => GetRef<Button>("BtnRanking");
        private Button BtnMission => GetRef<Button>("BtnMission");
        private Button BtnCommunity => GetRef<Button>("BtnCommunity");
        private Button BtnAds => GetRef<Button>("BtnAds");
        private Button BtnInvest => GetRef<Button>("BtnInvest");
        private Button BtnGemsShop  => GetRef<Button>("BtnGemsShop");
        private Button BtnOnHook  => GetRef<Button>("BtnOnHook");
        
            
        private TextMeshProUGUI TextExp => GetRef<TextMeshProUGUI>("TextExp");
        private TextMeshProUGUI TextName => GetRef<TextMeshProUGUI>("TextName");
        private TextMeshProUGUI TextLevel => GetRef<TextMeshProUGUI>("TextLevel");
        private Slider SliderExp => GetRef<Slider>("SliderExp");
        
        
        
        // left
        public void OnClick_BtnRanking() { Debug.Log("BtnRanking"); }
        public void OnClick_BtnMission() { Debug.Log("BtnMission"); }
        public void OnClick_BtnCommunity() { Debug.Log("BtnCommunity"); }
        
        //right
        public void OnClick_BtnAds() { Debug.Log("BtnAds"); }
        public void OnClick_BtnInvest() { Debug.Log("BtnInvest"); }
        public void OnClick_BtnGemsShop() { Debug.Log("BtnGemsShop"); }

        //bottom
        public void OnClick_BtnShop() {
            Debug.Log("OnClick_BtnShop");
            OpenAndClose(UIDefine.UIDrawCard);
        }

        public void OnClick_BtnHero() {
            Debug.Log("OnClick_BtnHeros"); 
            OpenAndClose(UIDefine.UIDemo03_ModelList);
        }

        public void OnClick_BtnGuild() {
            Debug.Log("OnClick_BtnGuild");
            OpenAndClose(UIDefine.UIDemo01_PureList);
        }

        public void OnClick_BtnInventory() {
            Debug.Log("OnClick_BtnInventory");
            RewardDatas.SetItems(10,20,30,0);
            OpenWindow(UIDefine.UIReward);
        }
        public void OnClick_BtnUpgrade() {
            Debug.Log("OnClick_BtnUpgrade");
            OpenAndClose(UIDefine.UIDemoStart);
        }
        public void OnClick_BtnPlay() {
            Debug.Log("OnClick_BtnUpgrade");
            OpenAndClose(UIDefine.UIDemo04_MutilSubPanel);
        }
        
        protected void OnSlider_SliderExp(float value) {
            Debug.Log("OnSlider_SliderExp " + value);
            TextExp.text = value.ToString();
        }

    }
}


























