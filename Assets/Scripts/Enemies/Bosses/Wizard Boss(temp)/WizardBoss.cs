using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBoss : Enemy
{
    private GameObject player;
    public int phase;

    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // create sleep phase and wait for player
        if (phase == 0 && detectPlayer() == true)
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
        float distance = Vector3.Distance(player.transform.position, this.transform.position);
        //Debug.Log(distance);
        if(distance <= 10)
        {
            setHealthbar();
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void setHealthbar()
    {
        HealthCanvas.gameObject.SetActive(true);
    }
}
