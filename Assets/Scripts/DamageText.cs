﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    private Vector3 Offset = new Vector3(0, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
        transform.localPosition += Offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
