using UnityEngine;
using UnityEngine.UI;

namespace GamesTan.UI {
    public class UIDemoStart : UIBaseWindow {
        
        private Button BtnClose => GetRef<Button>("BtnClose");
        private Button BtnTest => GetRef<Button>("BtnTest");

        protected override void OnClick_BtnClose() {
            base.OnClick_BtnClose();
            Debug.Log("UIDemoStart:BtnClose");
        }

        public void OnClick_BtnTest() {
            Debug.Log("UIDemoStart:OnClick_BtnTest");
        }
    }
}