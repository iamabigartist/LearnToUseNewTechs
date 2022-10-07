using GamesTan.Data;
using TMPro;
using UnityEngine;

namespace GamesTan.UI {
    public class UIPanelPlayerMoney: UIBasePanel {
        private TextMeshProUGUI TextValueDiamond => GetRef<TextMeshProUGUI>("TextValueDiamond");
        private TextMeshProUGUI TextValueCoin => GetRef<TextMeshProUGUI>("TextValueCoin");
        private TextMeshProUGUI TextValueDirty => GetRef<TextMeshProUGUI>("TextValueDirty");
        private TextMeshProUGUI TextValueExp => GetRef<TextMeshProUGUI>("TextValueExp");
        private TextMeshProUGUI TextValueTicket => GetRef<TextMeshProUGUI>("TextValueTicket");
        
        public void OnEvent_OnServerPlayerPropertyChanged(object param) {
            RefreshPlayerInfo();
        }

        private void RefreshPlayerInfo() {
            TextValueCoin.text = UIUtil.GetNumberStr(GameData.Instance.Coin);
            TextValueExp.text = UIUtil.GetNumberStr(GameData.Instance.Exp);
            TextValueDirty.text = UIUtil.GetNumberStr(GameData.Instance.Dirty);
            TextValueDiamond.text = UIUtil.GetNumberStr(GameData.Instance.Diamond);
            TextValueTicket.text = UIUtil.GetNumberStr(GameData.Instance.Ticket);
        }
        public void OnEvent_TestUIEvent(object param) {
            Debug.Log("UIPanelPlayerMoney OnEvent_TestUIEvent");
        }
        public override void DoStart() {
            base.DoStart();
            RefreshPlayerInfo();
        }

    }
}