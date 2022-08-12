﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{

    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    public Sprite healthPotionSprite;
    public Sprite manaPotionSprite;
    public Sprite goldSprite;
    public Sprite flintlockSprite;
    public Sprite shotgunSprite;
    public Sprite uziSprite;
    public Sprite ak47Sprite;
    public Sprite rpgSprite;

}
