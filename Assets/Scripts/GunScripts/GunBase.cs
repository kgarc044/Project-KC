using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunBase : MonoBehaviour
{
    public float speed;
    public float distance;
    public int ammoTotal;
    public int ammoMax;

    public bool isFlipped = false;
    public bool outOfAmmo;

    [SerializeField]
    private PlayerMove player;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    public GameObject UI;

    public void Start()
    {
        outOfAmmo = false;
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        ammoMax = ammoTotal;
        UI = GameObject.Find("UIManager");
    }
    public void FixedUpdate()
    {
        FollowPlayer(player.FacingRight);
    }
    // Start is called before the first frame update
    public abstract void Shoot();


    public void FollowPlayer(bool facingRight)
    {
        if (!outOfAmmo)
        {
            if (facingRight)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position + new Vector3(1.0f, 0, 0), speed * Time.deltaTime);
            }

            else
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position + new Vector3(-1.0f, 0, 0), speed * Time.deltaTime);
            }

            if (transform.position.x < playerTransform.position.x && !isFlipped)
            {
                transform.Rotate(0f, 180f, 0f);
                isFlipped = !isFlipped;
            }

            if (transform.position.x > playerTransform.position.x && isFlipped)
            {
                transform.Rotate(0f, 180f, 0f);
                isFlipped = !isFlipped;
            }
        }
    }

    public abstract void Special();

    public abstract void ThrowGun();

    public void ReturnGunStatus()
    {
        player.gunSummoned = false;
    }
}
