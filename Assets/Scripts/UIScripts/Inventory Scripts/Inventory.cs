using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.HealthPotion, quantity = 1 });
        AddItem(new Item { itemType = Item.ItemType.ManaPotion, quantity = 1 });
        AddItem(new Item { itemType = Item.ItemType.Gold, quantity = 1 });
        Debug.Log("Inventory");
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

}
