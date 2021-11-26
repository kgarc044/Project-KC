using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected float _Speed;
    protected int _Health;

    public float checkRadius = 0.01f;
    public Transform edgeCheck;
    [HideInInspector] public LayerMask ground;
    [HideInInspector] public float direction;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public bool isGrounded = true;

    public abstract float Speed { get; }
    public abstract int Health{ get; }

    void Awake()
    {
        ground = LayerMask.GetMask("Ground");
        rb = transform.GetComponent<Rigidbody2D>();
    }

    public void turn()
    {
        transform.RotateAround(transform.position, transform.up, 180f);
    }

    public void takeDamage(int damage)
    {
        _Health -= damage;
        if (_Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public abstract void move();

    public abstract void attack();
}
