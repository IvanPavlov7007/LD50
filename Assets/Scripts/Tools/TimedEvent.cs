using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEvent : OneShotEvent
{

    public bool onStart;
    public float triggerTime;

    protected override void Start()
    {
        base.Start();
        if (onStart) StartTimer();
    }

    float t = 0;
    public void StartTimer()
    {
        t = triggerTime;
    }

    private void Update()
    {
        t -= Time.deltaTime;
        if(t <= 0f && !played)
        {
            played = true;
            action.Invoke();
        }
    }
}
