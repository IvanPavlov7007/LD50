using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoIfAfterdeath : MonoBehaviour
{
    public int afterDeathNumber = 0;
    public bool biggerThan = false;
    public UnityEvent action;

    // Update is called once per frame
    void Start()
    {
        int count = IntersceneData.deathCounts;
        if (biggerThan)
        {
            if (afterDeathNumber > count)
                action.Invoke();
        }
        else if (afterDeathNumber == count)
            action.Invoke();

    }
}
