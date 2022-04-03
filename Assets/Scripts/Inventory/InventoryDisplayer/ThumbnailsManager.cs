using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThumbnailsManager : MonoBehaviour
{
    [SerializeField]
    GameObject itemDisplayerPrefab;

    Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameManager.instance.inventory;
        inventory.onItemAdded += onItemAdded;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onItemAdded(Item item)
    {
        var displayer = createItemDisplayer(item);
    }

    ItemDisplayer createItemDisplayer(Item item)
    {
        var obj = Instantiate(itemDisplayerPrefab, transform);
        var displayer = obj.GetComponent<ItemDisplayer>();
        displayer.Initialize(item);
        return displayer;
    }
}
