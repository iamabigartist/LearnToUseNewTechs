using System.Collections.Generic;
using GamesTan.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace GamesTan.UI {
    public class UIDrawCard : UIBaseWindow {
        private GameObject UIPanelPlayerMoney => GetRef<GameObject>("UIPanelPlayerMoney");
        private Transform PanelTen => GetRef<Transform>("PanelTen");
        private Transform PanelOne => GetRef<Transform>("PanelOne");
        private Transform DrawCardBtns => GetRef<Transform>("DrawCardBtns");


        private Button BtnDrawOne => GetRef<Button>("BtnDrawOne");
        private Button BtnDrawTen => GetRef<Button>("BtnDrawTen");
        private Button BtnBigCard => GetRef<Button>("BtnBigCard");
        private Button BtnAddTicket => GetRef<Button>("BtnAddTicket");
        private Button BtnAddDiamond => GetRef<Button>("BtnAddDiamond");
        private Button BtnAgain => GetRef<Button>("BtnAgain");
        private Button BtnClose => GetRef<Button>("BtnClose");
        private Button BtnOpenAll => GetRef<Button>("BtnOpenAll");

        private List<ItemData> datasTen = new List<ItemData>();
        private ItemData datasOne;

        private const int MaxCardCount = 10;
        enum EPanelType {
            Start,
            One,
            Ten
        }

        private EPanelType CurPanel = EPanelType.Start;

        public class ItemData {
            public int Idx;
            public bool IsOpened = false;
            public int ItemId;
            public Button Btn;
            public TextMeshProUGUI Text;

            public ItemData(int idx, Button btn) {
                IsOpened = false;
                this.Idx = idx;
                this.Btn = btn;
                Text = btn.GetComponentInChildren<TextMeshProUGUI>(true);
                Reset();
            }


            public void Reset() {
                Text.gameObject.SetActive(false);
                IsOpened = false;
                Btn.enabled = true;
                Btn.gameObject.GetOrAddComponent<PressedScale>().enabled = true;
                Btn.transform.Find("ImageCard").gameObject.SetActive(false);
                SetType(-1);
            }

            public void OnClick() {
                var roleId = DrawCardUtil.Results[Idx].Id;
                IsOpened = true;
                Text.text = roleId.ToString();
                Text.gameObject.SetActive(true);
                Btn.enabled = false;
                Btn.gameObject.GetOrAddComponent<PressedScale>().enabled = false;
                Btn.transform.localScale = Vector3.one;

                SetType(DrawCardUtil.Results[Idx].FrameType);
                Btn.transform.Find("ImageCard").gameObject.SetActive(true);
                Btn.transform.Find("ImageCard").GetComponent<Image>().sprite =
                    UIConfigIcon.GetSprite(roleId);
            }

            void SetType(int type) {
                var go = Btn.transform.Find("ImageNormal");
                go.gameObject.SetActive(type >= 0);
                go.GetComponent<Image>().color = UIConfigIcon.GetGradeBg(type*2);
            }
        }


        public override void DoStart() {
            base.DoStart();
            datasTen.Clear();
            for (int i = 0; i < MaxCardCount; i++) {
                int idx = i;
                var btn = PanelTen.RecursiveFindChild("BtnCard" + (i + 1)).GetComponent<Button>();
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(() => OnClickCard(idx));
                datasTen.Add(new ItemData(idx, btn));
            }
            datasOne = new ItemData(0, BtnBigCard);
            ShowPanel(EPanelType.Start);
        }

        public override void Close() {
            if (CurPanel != EPanelType.Start) {
                ShowPanel(EPanelType.Start);
            } else {
                base.Close();
            }
        }

        void ShowPanel(EPanelType type) {
            DrawCardBtns.gameObject.SetActive(type == EPanelType.Start);
            PanelOne.gameObject.SetActive(type == EPanelType.One);
            PanelTen.gameObject.SetActive(type == EPanelType.Ten);
            BtnOpenAll.gameObject.SetActive(type == EPanelType.Ten && true);
            BtnAgain.gameObject.SetActive(type == EPanelType.Ten && false);
            CurPanel = type;
            
            UIUtil.ToggleButton(BtnDrawOne,DrawCardUtil.Instance.CanDrawOne());
            UIUtil.ToggleButton(BtnDrawTen,DrawCardUtil.Instance.CanDrawTen());
            UIUtil.ToggleButton(BtnAgain,DrawCardUtil.Instance.CanDrawTen());
            ResetAll();
        }

        void OnClickCard(int idx) {
            Debug.Log("OnClickCard" + idx);
            datasTen[idx].OnClick();
        }

        public void OnClick_BtnBigCard() {
            Debug.Log("BtnBigCard");
            datasOne.OnClick();
        }

        public void OnClick_BtnDrawOne() {
            Debug.Log("BtnDrawOne");
            DrawCardUtil.Instance.DrawCardOne((isSucc) => { if (!isSucc) return; ShowPanel(EPanelType.One);});
        }

        public void OnClick_BtnDrawTen() {
            Debug.Log("BtnDrawTen");
            DrawCardUtil.Instance.DrawCardTen((isSucc) => { if (!isSucc) return; ShowPanel(EPanelType.Ten); });
        }


        public void OnClick_BtnAddTicket() {
            Debug.Log("BtnAddTicket");
        }

        public void OnClick_BtnAddDiamond() {
            Debug.Log("BtnAddDiamond");
        }

        public void OnClick_BtnAgain() {
            Debug.Log("BtnAgain");
            ResetAll();
            OnClick_BtnDrawTen();
        }

        private void ResetAll() {
            foreach (var btn in datasTen) {
                btn.Reset();
            }

            BtnOpenAll.gameObject.SetActive(true);
            BtnAgain.gameObject.SetActive(false);
            datasOne.Reset();
        }

        public void OnClick_BtnOpenAll() {
            Debug.Log("OnClick_BtnOpenAll");
            foreach (var btn in datasTen) {
                btn.OnClick();
            }

            BtnOpenAll.gameObject.SetActive(false);
            BtnAgain.gameObject.SetActive(true);
        }
    }
}