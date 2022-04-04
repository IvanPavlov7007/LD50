﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class OxygenManager : MonoBehaviour
{
    [SerializeField]
    public float initialOxygenLevel;
    float oxygenLevel;

    public UnityEvent onDeath;

    PlayerOxygen player;

    public float OxygenLevel { get { return oxygenLevel; } private set { oxygenLevel = value; } }

    public static OxygenManager instance { get; private set; }
    private void Awake()
    {
        instance = this;
        OxygenLevel = initialOxygenLevel;
    }

    private void Start()
    {
        player = PlayerMovement.Instance.GetComponent<PlayerOxygen>();
    }

    void Update()
    {
        oxygenLevel -= Time.deltaTime;
        player.oxygen = (oxygenLevel / initialOxygenLevel) * 100f;
        if (oxygenLevel < 0f)
            onDeath.Invoke();
    }
}
