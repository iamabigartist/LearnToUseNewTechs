using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonoDemoButton : MonoBehaviour {
#if UNITY_EDITOR
    public bool IsInteract;
    private TextMeshProUGUI comp;
    void Start() {
        if (IsInteract) {
            var img = transform.Find("Icon")?.GetComponent<Image>();
            if (img != null) {
                img.color = new Color(0,0.81f,0.33f);
            }
        }

        if (comp == null)
            comp = GetComponentInChildren<TextMeshProUGUI>();
        if (comp != null) {
            comp.text = name.Replace("Btn", "");
        }
    }
#endif
}