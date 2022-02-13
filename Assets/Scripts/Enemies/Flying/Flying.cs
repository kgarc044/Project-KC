using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : Enemy
{
    private GameObject player;
    public Transform down;

    bool canShoot;

    public GameObject fireball;
    public float fireRate;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fireRate = 1f;
        canShoot = true;
        Speed = .03f;
        maxHealth = 50f;
        Health = maxHealth;
        bulletSpeed = 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (detectPlayer() && canShoot)
        {
            StartCoroutine(attack());
        }
        move();
    }

    public override void move()
    {
        float vely = Mathf.Sin(Time.fixedTime * 5);
        float xpos = Mathf.MoveTowards(rb.transform.position.x, player.transform.position.x, Speed);
        rb.transform.position = new Vector2(xpos, rb.position.y);
        rb.velocity = new Vector2(rb.velocity.x, vely);
    }

    public override IEnumerator attack()
    {
        GameObject f = Instantiate(fireball, down.position, transform.localRotation);
        f.GetComponent<Rigidbody2D>().velocity = transform.up * -1f * bulletSpeed;
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    public override bool detectPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(down.position, transform.TransformDirection(Vector2.up * -1), 10f);

        if (hit)
        {
            if (hit.collider.tag == "Player")
            {
                Debug.DrawRay(down.position, (transform.up * -1f) * 10f, Color.green);
                return true;
            }
            else
            {
                Debug.DrawRay(down.position, (transform.up * -1f) * hit.distance, Color.red);
            }
        }
        else
        {
            Debug.DrawRay(down.position, (transform.up * -1f) * 10f, Color.red);
        }
        return false;
    }
}