using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    string currentAction;
    float maxChargeDuration;
    // Start is called before the first frame update
    void Start()
    {
        currentAction = "moving";
        Speed = 3f;
        maxHealth = 220f;
        Health = maxHealth;
        maxChargeDuration = 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkFloor();
        if (detectPlayer() && currentAction == "moving")
        {
            StartCoroutine("attack");
        }
        else if(currentAction == "moving")
        {
            move();
        }
        else if(currentAction == "charging")
        {
            chargeattack();
        }

        setHealthbar();
    }

    public void chargeattack()
    {
        if ((rb.velocity.x < 0.01 && rb.velocity.x > 0) || (isGrounded && edge))
        {
            turn();
            StopCoroutine("attack");
            currentAction = "moving";
        }
        rb.velocity = new Vector2(transform.right.x * Speed * 2f, rb.velocity.y);
    }

    public override void move()
    {
        if ((rb.velocity.x < 0.01 && rb.velocity.x > 0) || (isGrounded && edge))
        {
            turn();
        }
        rb.velocity = new Vector2(transform.right.x * Speed, rb.velocity.y);
    }

    public override IEnumerator attack() // not yet finished. Have to look into wait until function so that I can properly animate certain movement.                 Should also create a groundcheck object seperated from the edgecheck object
    {
        currentAction = "";
        isGrounded = false;
        rb.velocity = new Vector2(0, rb.velocity.y);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100));

        yield return new WaitForSeconds(0.3f);

        yield return new WaitUntil(() => isGrounded = true);
        currentAction = "charging";

        yield return new WaitForSeconds(maxChargeDuration);
        currentAction = "moving";
    }

    public override bool detectPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(front.position, transform.TransformDirection(Vector2.right), 10f);

        if (hit)
        {
            if (hit.collider.tag == "Player")
            {
                Debug.DrawRay(front.position, transform.right * 10f, Color.green);
                return true;
            }
            else
            {
                Debug.DrawRay(front.position, transform.right * hit.distance, Color.red);
            }
        }
        else
        {
            Debug.DrawRay(front.position, transform.right * 10f, Color.red);
        }
        return false;
    }
}