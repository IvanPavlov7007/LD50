using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeInactiveObject : MonoBehaviour
{
    public void SetChilderActive(bool active)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(active);
        }
    }
}
