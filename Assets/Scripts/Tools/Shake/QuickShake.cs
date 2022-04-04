using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MilkShake;

[RequireComponent(typeof(Shaker))]
public class QuickShake : MonoBehaviour
{
    [SerializeField]
    private ShakePreset shakePreset;
    [SerializeField]
    private ShakeParameters shakeParams;
    Shaker shaker;
    MouseCameraMovement mcm;

    void Start()
    {
        shaker = GetComponent<Shaker>();
        mcm = GetComponent<MouseCameraMovement>();
    }

    public void Shake()
    {
        StartCoroutine(turnOffShake());
    }

    IEnumerator turnOffShake()
    {
        shaker.enabled = true;
        mcm.enabled = false;
        if (shakePreset != null)
            shaker.Shake(shakePreset);
        else
            shaker.Shake(shakeParams);
        yield return new WaitForSeconds(2f);
        shaker.enabled = false;
        mcm.enabled = true;

    }
}
