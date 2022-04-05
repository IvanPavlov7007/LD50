using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OxygenBar : MonoBehaviour
{
    Image img;
    OxygenManager ox;

    private void Start()
    {
        img = GetComponent<Image>();
        ox = OxygenManager.instance;
    }

    private void Update()
    {
        img.fillAmount = ox.OxygenLevel / 100f;
    }
}
