using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("Inventory frames");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }
    
    public void SetInventory(Inventory inventory)
    {
        Debug.Log("SetInventory");
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach(Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        float x = -4.5f;
        float y = 0.5f;
        int count = 1;
        float itemSlotCellSize = 50f;
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();

            TextMeshProUGUI countText = itemSlotRectTransform.Find("quantityText").GetComponent<TextMeshProUGUI>();
            if(item.quantity > 1)
            {
                countText.SetText(item.quantity.ToString());
            }
            else
            {
                countText.SetText("");
            }
            TextMeshProUGUI useText = itemSlotRectTransform.Find("useNum").GetComponent<TextMeshProUGUI>();
            useText.SetText(count.ToString());


            x++;
            count++;
            if(x > 4.5)
            {
                x = -4.5f;
                y--;
            }
        }
        Debug.Log("RefInventory");
    }
}
