using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity);
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        Destroy(gameObject);
        //player hit
    }
}
