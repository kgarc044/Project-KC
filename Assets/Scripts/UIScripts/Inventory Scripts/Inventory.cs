using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public event EventHandler OnItemListChanged;

    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        //AddItem(new Item { itemType = Item.ItemType.HealthPotion, quantity = 1 });
        //AddItem(new Item { itemType = Item.ItemType.ManaPotion, quantity = 1 });
        //AddItem(new Item { itemType = Item.ItemType.Gold, quantity = 1 });
        AddItem(new Item { itemType = Item.ItemType.Flintlock, quantity = 1 });
        AddItem(new Item { itemType = Item.ItemType.Shotgun, quantity = 1 });
        AddItem(new Item { itemType = Item.ItemType.Uzi, quantity = 1 });
        AddItem(new Item { itemType = Item.ItemType.Rifle, quantity = 1 });
        AddItem(new Item { itemType = Item.ItemType.Rpg, quantity = 1 });
        Debug.Log("Inventory");
    }

    public void AddItem(Item item)
    {
        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList)
            {
                if(inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.quantity += item.quantity;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory)
            {
                itemList.Add(item);
            }
        }
        else
        {
            itemList.Add(item);
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

}
