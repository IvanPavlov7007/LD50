using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class OxygenManager : MonoBehaviour
{
    [SerializeField]
    public float initialOxygenLevel;
    float oxygenLevel;

    public UnityEvent onDeath;

    PlayerOxygen player;

    public float OxygenLevel { get { return oxygenLevel; } private set { oxygenLevel = value; } }

    public static OxygenManager instance { get; private set; }
    private void Awake()
    {
        instance = this;
        OxygenLevel = initialOxygenLevel;
        if (IntersceneData._this)
            addOxygen(3600f);
    }

    private void Start()
    {
        player = PlayerMovement.Instance.GetComponent<PlayerOxygen>();
    }

    public void addOxygen(float seconds)
    {
        oxygenLevel += seconds;
    }

    bool dead = false;

    void Update()
    {
        if (dead)
            return;
        oxygenLevel -= Time.deltaTime;
        player.oxygen = (oxygenLevel / initialOxygenLevel) * 100f;
        if (oxygenLevel < 0f)
        {
            dead = true;
            onDeath.Invoke();
        }
    }
}
