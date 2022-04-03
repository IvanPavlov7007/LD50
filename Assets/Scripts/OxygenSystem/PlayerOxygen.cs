using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOxygen : MonoBehaviour
{
    [Range(0,100)]
    public float oxygen=100;
    public AudioSource audioSource;

    public AudioClip normalBreathing;
    public AudioClip hardBreathing;
    public AudioClip death;

    public float lowOxThreshold=25;

    OxygenState state = OxygenState.Normal;

    enum OxygenState
    {
        Normal,
        Low,
        None
    }

    // Update is called once per frame
    void Update()
    {
        if(oxygen > lowOxThreshold && state != OxygenState.Normal)
        {
            Debug.Log(state);
            audioSource.clip = normalBreathing;
            audioSource.loop = true;
            audioSource.Play();
            state = OxygenState.Normal;
        } else if(oxygen > 0 && oxygen <= lowOxThreshold && state != OxygenState.Low)
        {
            audioSource.clip = hardBreathing;
            audioSource.loop = true;
            audioSource.Play();
            state = OxygenState.Low;
        }
        if(oxygen == 0 && state != OxygenState.None)
        {
            state = OxygenState.None;
            Suffocate();
        }
    }

    public void Suffocate()
    {
        audioSource.clip = death;
        audioSource.loop = false;
        audioSource.Play();
    }
}
