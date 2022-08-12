using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBoss : Enemy
{
    [HideInInspector]public GameObject player;

    public GameObject fireball;
    public GameObject test;
    public float bulletSpeed;

    public Collider2D detect;
    public Animator animator;
    public int phase;

    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
        player = GameObject.FindWithTag("Player");
        BossName.text = name;
        phase = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // create sleep phase and wait for player
        if (phase == 1)
        {
            phase++;
        }
        // create function per phase for clarity sake

        calculateHealthbar();
    }

    // maybe create a teleport or something
    public override void move()
    {

    }

    // THERES A LOT TO REQRITE HERE
    public override IEnumerator attack()
    {
        yield return new WaitForSeconds(0f);
    }

    public override bool detectPlayer()
    {
        return true;
    }

    public override void setHealthbar()
    {
        HealthCanvas.gameObject.SetActive(true);
        animator.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            phase++;
            detect.enabled = false;
            setHealthbar();
        }
    }
}
