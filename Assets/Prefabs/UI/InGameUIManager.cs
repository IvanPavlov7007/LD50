using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InGameUIManager : MonoBehaviour
{
    public static InGameUIManager instance;

    public TextMeshProUGUI objectUnderPointerHint;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        objectUnderPointerHint.SetText("");
    }
}
