﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 50; // Placeholder damage for flintlock bullet

    [SerializeField]
    private Rigidbody2D bulletRB;

    void Start()
    {
        bulletRB.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.tag == "Enemy")
        {
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            e.takeDamage(damage);
        }
    }
}
