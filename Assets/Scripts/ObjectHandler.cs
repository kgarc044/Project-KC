using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{

    void Start()
    {
        ItemWorld.SpawnItemWorld(new Vector3(1, 2), new Item { itemType = Item.ItemType.HealthPotion, quantity = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(2, 3), new Item { itemType = Item.ItemType.ManaPotion, quantity = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(3, 4), new Item { itemType = Item.ItemType.Gold, quantity = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(4, 2), new Item { itemType = Item.ItemType.HealthPotion, quantity = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(5, 3), new Item { itemType = Item.ItemType.ManaPotion, quantity = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(6, 4), new Item { itemType = Item.ItemType.Gold, quantity = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(7, 2), new Item { itemType = Item.ItemType.HealthPotion, quantity = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(8, 3), new Item { itemType = Item.ItemType.ManaPotion, quantity = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(9, 4), new Item { itemType = Item.ItemType.Gold, quantity = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(10, 4), new Item { itemType = Item.ItemType.Gold, quantity = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(11, 4), new Item { itemType = Item.ItemType.Gold, quantity = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(12, 4), new Item { itemType = Item.ItemType.Gold, quantity = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(13, 4), new Item { itemType = Item.ItemType.Gold, quantity = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(14, 4), new Item { itemType = Item.ItemType.Gold, quantity = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(15, 4), new Item { itemType = Item.ItemType.Gold, quantity = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(16, 4), new Item { itemType = Item.ItemType.Gold, quantity = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(17, 4), new Item { itemType = Item.ItemType.Gold, quantity = 1 });
    }

    void Update()
    {
        
    }
}
