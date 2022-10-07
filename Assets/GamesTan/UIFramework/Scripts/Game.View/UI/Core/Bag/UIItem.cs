using GamesTan.Data;
using TMPro;
using UnityEngine.UI;

namespace GamesTan.UI {
    public interface IItemListWindow {
        void OnClickItem(UIItem item);
    }

    public class UIItem : UIBaseItem, IScrollCell {
        public int Idx;

        protected UIPanelItemList _bag;
        protected BaseItemData _data;
        public BaseItemData Data => _data;

        public long EntityId => Data.EntityId;
        public Button BtnSelf => Holder.GetComponent<Button>();
        public Image ImageBg => GetRef<Image>("ImageBg");
        public Image ImageGradeFrame => GetRef<Image>("ImageGradeFrame");
        public Image ImageItem => GetRef<Image>("ImageItem");
        public Image GoLock => GetRef<Image>("GoLock");
        public Image ImageFocus => GetRef<Image>("ImageFocus");
        public Image Notification => GetRef<Image>("Notification");
        public TextMeshProUGUI TextCount => GetRef<TextMeshProUGUI>("TextCount");

        public void DoInit(UIPanelItemList bag, BaseItemData data, int idx, bool isOn) {
            if (_bag == null) {
                this._bag = bag;
                Bind(gameObject);
            }

            this.Idx = idx;
            this._data = data;
            ImageFocus.gameObject.SetActive(isOn);
            TextCount.gameObject.SetActive(data.Count > 1);
            TextCount.text = UIUtil.GetCountStr(data.Count);
            var spriteId = data.Id;
            var grade = data.Grade;
            ImageBg.color = UIConfigIcon.GetGradeBg(grade);
            ImageGradeFrame.gameObject.SetActive(false);

            ImageItem.sprite = UIConfigIcon.GetSprite(spriteId);
            if (BtnSelf != null) {
                BtnSelf.GetOrAddComponent<PressedScale>();
                BtnSelf.onClick.RemoveListener(OnClickItem);
                BtnSelf.onClick.AddListener(OnClickItem); 
            }

            OnInit(isOn);
        }

        protected virtual void OnClickItem() {
            _bag.OnClickItem(this);
        }

        protected virtual void OnInit(bool isOn) {
        }
        public void Toggle(bool isOn) {
            ImageFocus.gameObject.SetActive(isOn);
        }
    }
}