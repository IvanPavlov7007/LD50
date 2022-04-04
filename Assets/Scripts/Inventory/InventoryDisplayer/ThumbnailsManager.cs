using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThumbnailsManager : MonoBehaviour
{
    [SerializeField]
    GameObject itemDisplayerPrefab;
    public CraftingArea craftingArea { get; set; }

    Inventory inventory;

    RectTransform rectTransform;

    List<ItemDisplayer> displayers;

    public static ThumbnailsManager instance{ get;private set;}

    private void Awake()
    {
        instance = this;
        displayers = new List<ItemDisplayer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        inventory = GameManager.instance.inventory;
        inventory.onItemAdded += onItemAdded;
        craftingArea = GetComponentInChildren<CraftingArea>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onItemAdded(Item item)
    {
        var displayer = createItemDisplayer(item);
        displayers.Add(displayer);
    }

    public void destroyThumbnail(ItemDisplayer displayer)
    {
        displayers.Remove(displayer);
        Destroy(displayer.gameObject);
    }

    void onItemRemoved(Item item)
    {
        var displayer = displayers.Find(x => x.item == item);
        displayers.Remove(displayer);
        Destroy(displayer);
    }

    ItemDisplayer createItemDisplayer(Item item)
    {
        //var obj = Instantiate(itemDisplayerPrefab, new Vector3(Random.Range(0,rectTransform.rect.width), Random.Range(0, rectTransform.rect.height), 0), Quaternion.identity  ,transform);
        var obj = Instantiate(itemDisplayerPrefab, transform);

        var displayer = obj.GetComponent<ItemDisplayer>();
        displayer.Initialize(item);
        return displayer;
    }
}
