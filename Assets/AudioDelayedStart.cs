using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDelayedStart : MonoBehaviour
{
    public AudioSource audioSource;
    public float delay = 2;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayDelayed(delay);
    }
}
