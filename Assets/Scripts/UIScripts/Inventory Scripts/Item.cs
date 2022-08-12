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
        Flintlock,
        Shotgun,
        Uzi,
        Rifle,
        Rpg
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
            case ItemType.Flintlock:        return ItemAssets.Instance.flintlockSprite;
            case ItemType.Shotgun:          return ItemAssets.Instance.shotgunSprite;
            case ItemType.Uzi:              return ItemAssets.Instance.uziSprite;
            case ItemType.Rifle:            return ItemAssets.Instance.ak47Sprite;
            case ItemType.Rpg:              return ItemAssets.Instance.rpgSprite;
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
