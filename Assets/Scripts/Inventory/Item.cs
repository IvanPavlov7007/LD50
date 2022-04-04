using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public Sprite thumbnail;

    public bool hasAction;
    public UnityEvent useAction;


    //TODO: Delete from Inventory
    public bool activate()
    {
        useAction.Invoke();
        return hasAction;
    }

}
