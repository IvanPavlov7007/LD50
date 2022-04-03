using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingArea : MonoBehaviour
{
    public List<ItemDisplayer> displayersInArea { get; set; }
    public RectTransform rectTransform { get; private set; }
    private void Awake()
    {
        displayersInArea = new List<ItemDisplayer>();
        rectTransform = GetComponent<RectTransform>();
    }

    public ItemDisplayer tryCombyingItems(ItemDisplayer displayer)
    {
        var inventory = GameManager.instance.inventory;
        for (int i = 0; i < displayersInArea.Count; i++)
        {
            if (inventory.CombineItems(displayer.item, displayersInArea[i].item))
            {
                return displayersInArea[i];
            }
        }
        return null;
    }
}
