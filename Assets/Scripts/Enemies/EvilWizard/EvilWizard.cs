using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilWizard : Enemy
{
    public GameObject fireball;
    public float fireRate;
    public float bulletSpeed;
    bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        //Evil wizard presets
        fireRate = 1f;
        canShoot = true;
        Speed = 1f;
        maxHealth = 100f;
        Health = maxHealth;
        bulletSpeed = 3f;
    }

    void FixedUpdate()
    {
        checkFloor();
        if (detectPlayer() && canShoot)
        {
            StartCoroutine(attack());
        }
        else if(canShoot) // Evil Wizard will stand still to use fireballs
        {
            move();
        }

        setHealthbar();
    }

    public override void move()
    {
        if ((rb.velocity.x < 0.01 && rb.velocity.x > 0) || edge)
        {
            turn();
        }
        else
        {
            rb.velocity = new Vector2(transform.right.x * Speed, rb.velocity.y);
        }
    }

    public override IEnumerator attack()
    {
        GameObject f = Instantiate(fireball, front.position, transform.localRotation);
        f.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
 
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    public override bool detectPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(front.position, transform.TransformDirection(Vector2.right), 5f);

        if (hit)
        {
            if (hit.collider.tag == "Player")
            {
                Debug.DrawRay(front.position, transform.right * 5f, Color.green);
                return true;
            }
            else
            {
                Debug.DrawRay(front.position, transform.right * hit.distance, Color.red);
            }
        }
        else
        {
            Debug.DrawRay(front.position, transform.right * 5f, Color.red);
        }
        return false;
    }
}
