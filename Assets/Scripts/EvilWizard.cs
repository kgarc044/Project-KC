using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilWizard : Enemy
{
    [SerializeField] GameObject bullet;
    float fireRate;
    float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void FixedUpdate()
    {
        move();
        attack();
    }

    public override void move()
    {
        // If there is a gap in fron of the enemy or the enemy hit a wall
        isGrounded = Physics2D.OverlapCircle(edgeCheck.position, checkRadius, ground);

        if ((rb.velocity.x < 0.01 && rb.velocity.x > 0) || !isGrounded)
        {
            turn();
        }
        else
        {
            rb.velocity = new Vector2(transform.right.x * Speed, rb.velocity.y);
        }
    }

    public override void attack()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, new Vector2(transform.position.x + transform.right.x, transform.position.y), transform.localRotation);
            nextFire = Time.time + fireRate;
            
            // Used to test only
            //turn();
        }
    }

    public override float Speed   // Enemy Speed
    {
        get
        {
            return 1;
        }
    }

    public override int Health   // Enemy Health
    {
        get
        {
            return 100;
        }
    }
}
