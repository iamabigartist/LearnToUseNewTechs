using UnityEngine;
using UnityEngine.UI;

namespace GamesTan.UI {
    public static class UIUtil {
        public static string GetNumberStr(long number) {
            if (number < 100000) {
                return number.ToString();
            }
            if (number < 100000000) {
                return $"{number / 1000}K";
            }
            return $"{number / 1000000}M";
        }
        public static string GetCountStr(long number) {
            if (number < 10000) {
                return number.ToString();
            }
            if (number < 1000000) {
                return $"{number / 1000}K";
            }
            return $"{number / 1000000}M";
        }
        public static void ToggleButton(Button btn, bool isOn) {
            btn.GetComponent<Image>().color = isOn ? Color.white : Color.gray;
            btn.enabled = isOn;
            btn.GetOrAddComponent<PressedScale>().enabled = isOn;
        }
    }
}