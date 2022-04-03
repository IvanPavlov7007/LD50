using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDisplayer : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler 
{

    RectTransform rectTransform;
    Camera cam;
    Image img;
    Inventory inventory;

    public Item item { get; private set; }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        img = GetComponentInChildren<Image>();
    }

    private void Start()
    {
        cam = Camera.main;
        inventory = GameManager.instance.inventory;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var craftingArea = ThumbnailsManager.instance.craftingArea;
        if (RectTransformUtility.RectangleContainsScreenPoint(craftingArea.rectTransform, eventData.position))
        {
            var otherPart = craftingArea.tryCombyingItems(this);
            if (otherPart != null)
            {
                ThumbnailsManager.instance.destroyThumbnail(this);
                ThumbnailsManager.instance.destroyThumbnail(otherPart);
            }
            else
                craftingArea.displayersInArea.Add(this);
        }
        else
            craftingArea.displayersInArea.Remove(this);
        trySendToReciever(eventData.position);
    }

    bool trySendToReciever(Vector3 position)
    {
        RaycastHit hit;
        Physics.Raycast(cam.ScreenPointToRay(position), out hit, 50);
        Transform t = hit.transform;
        if (t != null)
        {
            var reciever = t.GetComponentInParent<ItemReciever>();
            if(reciever != null && reciever.Drop(item))
            {
                inventory.items.Remove(item);
                Destroy(item.gameObject);
                ThumbnailsManager.instance.destroyThumbnail(this);
                return true;
            }
            
        }

        return false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void Initialize(Item item)
    {
        this.item = item;
        if(item.thumbnail != null)
            img.sprite = item.thumbnail;
    }
}
