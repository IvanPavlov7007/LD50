using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpecificItemReciever : ItemReciever
{
    public Item itemToBeRecievied;
    public UnityEvent eventWhenRecieved;

    public override bool Drop(Item item)
    {
        if(item == itemToBeRecievied)
        {
            eventWhenRecieved.Invoke();
            return true;
        }
        return false;
    }
}


