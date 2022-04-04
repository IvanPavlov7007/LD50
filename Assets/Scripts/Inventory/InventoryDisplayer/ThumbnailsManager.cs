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

    [SerializeField]
    Toggle inventoryToggle;
    [SerializeField]
    Transform initPos;
    [SerializeField]
    Vector3 stepSize;
    int step = 0;

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
        inventoryToggle.isOn = true;
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
        var obj = Instantiate(itemDisplayerPrefab, initPos.position + stepSize * step,Quaternion.identity, transform);
        step++;
        if (step == 5)
            step = 0;
        var displayer = obj.GetComponent<ItemDisplayer>();
        displayer.Initialize(item);
        return displayer;
    }
}
