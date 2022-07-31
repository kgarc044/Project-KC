 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        HealthPotion,
        ManaPotion,
        Gold,
        Gun,
    }

    public ItemType itemType;
    public int quantity;

    public Sprite GetSprite()
    {
        //Debug.Log(itemType);
        switch (itemType)
        {
            default:
            case ItemType.HealthPotion:     return ItemAssets.Instance.healthPotionSprite;
            case ItemType.ManaPotion:       return ItemAssets.Instance.manaPotionSprite;
            case ItemType.Gold:             return ItemAssets.Instance.goldSprite;
        }
    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.HealthPotion: 
            case ItemType.ManaPotion: 
                return true;
            case ItemType.Gold:
                return false;
        }
    }
}
