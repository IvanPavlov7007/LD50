using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenManager : MonoBehaviour
{
    [SerializeField]
    float initialOxygenLevel;
    float oxygenLevel;
    public float OxygenLevel { get { return oxygenLevel; } private set { oxygenLevel = value; } }

    public static OxygenManager instance { get; private set; }
    private void Awake()
    {
        instance = this;
        OxygenLevel = initialOxygenLevel;
    }

    void Update()
    {
        oxygenLevel -= Time.deltaTime;
    }
}
