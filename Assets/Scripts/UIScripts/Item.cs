using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Gun1,
        Gun2,
        Gun3,
        Gun4,
        Gun5
    }

    public ItemType itemType;
    public int num;
}
