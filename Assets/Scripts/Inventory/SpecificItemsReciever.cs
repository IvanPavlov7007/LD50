using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpecificItemsReciever : ItemReciever
{
    public List<Item> itemsToBeRecievied;
    public UnityEvent eventWhenRecieved;

    public override bool Drop(Item item)
    {
        if (itemsToBeRecievied.Contains(item))
        {
            eventWhenRecieved.Invoke();
            return true;
        }
        return false;
    }
}
