using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "collection", menuName = "ScriptableObjects/Inventory", order = 2)]
public class Inventory : MonoBehaviour
{
    public List<Item> items;
    public List<Item> combinations;



    public Item CombineItems(Item i1, Item i2)
    {
        if (i1 == i2)
            return null;
        return null;
    }

    public void addItem(Item item)
    {
        items.Add(item);
        if (onItemAdded != null)
            onItemAdded(item);
    }

    public event ItemAction onItemAdded;
    public event ItemAction ItemCreated;
}

    public delegate void ItemAction(Item item);