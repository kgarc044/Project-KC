using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunBase : MonoBehaviour
{
    public float speed;
    public float distance;

    public PlayerMove player;
    public Transform playerTransform;

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

        if (transform.position.x < playerTransform.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        if (transform.position.x > playerTransform.position.x)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }
    //public abstract void Special();

    //public abstact void Reload();
}
