using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "collection", menuName = "ScriptableObjects/Inventory", order = 2)]
[RequireComponent(typeof(DialogPoint))]
public class Inventory : MonoBehaviour
{
    public List<Item> items;
    public List<Combination> combinations;
    public Combination bookCombination;

    DialogPoint dialogPoint;

    private void Awake()
    {
        dialogPoint = GetComponent<DialogPoint>();
    }

    public bool CombineItems(Item i1, Item i2)
    {
        if (i1 == i2)
            return false;

        foreach (var c in combinations)
        {
            if ((c.i1 == i1 && c.i2 == i2) || (c.i1 == i2 && c.i2 == i1))
            {
                dialogPoint.StartDialog(c.dialog);
                return c.combinable;
            }
        }
        return false;
    }

    public void addItem(Item item)
    {
        if (items.Contains(item))
            return;
        items.Add(item);
        if (onItemAdded != null)
            onItemAdded(item);
    }

    public void addCombination(Combination c)
    {
        combinations.Add(c);
    }

    //Fast fix
    public void addBookCombination()
    {
        combinations.Remove(combinations.Find(x => (x.i1 == bookCombination.i1 && bookCombination.i2 == x.i2) || (x.i1 == bookCombination.i2 && bookCombination.i2 == x.i1)));
        addCombination(bookCombination);
    }

    public event ItemAction onItemAdded;
    public event ItemAction ItemCreated;
}

public delegate void ItemAction(Item item);

[System.Serializable]
public struct Combination 
{
    public Item i1, i2;
    public Dialog dialog;
    public bool combinable;
}
