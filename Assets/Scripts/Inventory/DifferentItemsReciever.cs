using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DifferentItemsReciever : ItemReciever
{
    public List<ItemAndAction> itemsAndActinos;
    public override bool Drop(Item item)
    {
        var i = itemsAndActinos.Find(x => x.item == item);
        if (i.item != null && item == i.item)
        {
            i.action.Invoke();
            return i.itemToBeRecieved;
        }
        return false;
    }
}

[System.Serializable]
public struct ItemAndAction
{
    public Item item;
    public UnityEvent action;
    public bool itemToBeRecieved;
}