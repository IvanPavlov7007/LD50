using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointerHint : MonoBehaviour
{
    TextMeshProUGUI displayer;
    void Start()
    {
        displayer = InGameUIManager.instance.objectUnderPointerHint.GetComponent<TextMeshProUGUI>();
    }

    private void OnMouseEnter()
    {
        displayer.SetText(name);
    }

    private void OnMouseExit()
    {
        displayer.SetText(string.Empty);
    }
}
