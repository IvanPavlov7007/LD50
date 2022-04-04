using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCounter : MonoBehaviour
{
    TextMeshPro textMeshPro;
    void Awake()
    {
        textMeshPro = GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        int deathcounts = IntersceneData.deathCounts;
        if (deathcounts > 0)
            textMeshPro.SetText("Count of deaths: " + deathcounts.ToString());
        else
            textMeshPro.SetText("");
    }
}
