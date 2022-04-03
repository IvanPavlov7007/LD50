using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OxygenDislpayer : MonoBehaviour
{
    TextMeshProUGUI text;
    OxygenManager manager;
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        manager = OxygenManager.instance;
    }
    void Update()
    {
        text.SetText(string.Format("Oxygen : {0:0.00}s", manager.OxygenLevel));
    }
}
