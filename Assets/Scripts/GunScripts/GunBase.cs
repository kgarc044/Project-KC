using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunBase : MonoBehaviour
{
    public float speed;
    public float distance;

    public bool isFlipped = false;

    [SerializeField]
    private PlayerMove player;
    [SerializeField]
    private Transform playerTransform;

    public void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        playerTransform = GameObject.FindWithTag("Player").transform;
    }
    public void FixedUpdate()
    {
        FollowPlayer(player.FacingRight);
    }
    // Start is called before the first frame update
    public abstract void Shoot();


    public void FollowPlayer(bool facingRight)
    {
        //if (Vector2.Distance(transform.position, playerTransform.position) > 2)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, 2f * Time.deltaTime);
        //}
        if (facingRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position + new Vector3(1.5f, 0, 0), speed * Time.deltaTime);
        }

        else
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position + new Vector3(-1.5f, 0, 0), speed * Time.deltaTime);
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
    //public abstract void Special();

    //public abstact void Reload();
}
