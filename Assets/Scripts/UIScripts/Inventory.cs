using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.Gun1, num = 1 });
        Debug.Log("Inventory");
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

}
