using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject edgecheck;

    public float Speed;
    public int Health;

    private LayerMask ground;
    private float direction;
    private BoxCollider2D ec;
    private Rigidbody2D rb;

    void Awake()
    {
        ground = LayerMask.GetMask("ground");
        rb = transform.GetComponent<Rigidbody2D>();
        ec = edgecheck.GetComponent<BoxCollider2D>();
        direction = transform.right.x;
    }

    void turn()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        direction *= -1;
    }

    public void patrol()
    {
        // If there is a gap in fron of the enemy or the enemy hit a wall

        if ((rb.velocity.x < 0.01 && rb.velocity.x > 0) || !ec.IsTouchingLayers(ground))
        {
            turn();
        }
        else
        {
            rb.velocity = new Vector2(direction * Speed, rb.velocity.y);
        }
    }

    public void takeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
