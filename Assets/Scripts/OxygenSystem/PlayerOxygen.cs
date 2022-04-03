using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Audio;

public class PlayerOxygen : MonoBehaviour
{
    [Range(0, 100)]
    public float oxygen = 100;
    public AudioSource audioSource;

    public AudioClip normalBreathing;
    public AudioClip hardBreathing;
    public AudioClip death;

    public DimManager dimManager;

    public float lowOxThreshold = 25;

    public float maxAberration = 8;

    OxygenState state = OxygenState.Normal;

    public AudioMixer mixer;

    enum OxygenState
    {
        Normal,
        Low,
        None
    }

    PostProcessVolume ppv;
    ChromaticAberration chroma;

    void Start()
    {
        chroma = ScriptableObject.CreateInstance<ChromaticAberration>();
        chroma.enabled.Override(true);
        chroma.intensity.Override(0);
        ppv = PostProcessManager.instance.QuickVolume(8, 9001f, new PostProcessEffectSettings[] { chroma });
        ppv.isGlobal = true;
    }

    void setLowPass(float intensity)
    {
        float v = Mathf.Lerp(11000f, 20f, Mathf.SmoothStep(0f, 1f, intensity));
        mixer.SetFloat("envLoPass", v);
        mixer.SetFloat("musicLoPass", v);
    }

    // Update is called once per frame
    void Update()
    {
        if (oxygen > lowOxThreshold && state != OxygenState.Normal)
        {
            audioSource.clip = normalBreathing;
            audioSource.loop = true;
            audioSource.Play();
            state = OxygenState.Normal;
            setLowPass(0);
            dimManager.Visibility = 1f;
            chroma.intensity.value = 0;
        }
        else if (oxygen > 0 && oxygen <= lowOxThreshold && state != OxygenState.Low)
        {
            audioSource.clip = hardBreathing;
            audioSource.loop = true;
            audioSource.Play();
            state = OxygenState.Low;
        }
        if (oxygen == 0 && state != OxygenState.None)
        {
            setLowPass(1f);
            dimManager.Visibility = 0f;
            chroma.intensity.value = maxAberration;
            state = OxygenState.None;
            Suffocate();
        }
        if (state == OxygenState.Low)
        {
            float deathness = (1f - (oxygen / lowOxThreshold));
            dimManager.Visibility = 1f - deathness;
            chroma.intensity.value = deathness * maxAberration;
            setLowPass(deathness);
        }
    }


    public void Suffocate()
    {
        audioSource.clip = death;
        audioSource.loop = false;
        audioSource.Play();
    }

    void OnDestroy()
    {
        RuntimeUtilities.DestroyVolume(ppv, true, true);
    }
}
