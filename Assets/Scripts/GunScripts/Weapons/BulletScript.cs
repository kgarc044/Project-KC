using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 20f;

    [SerializeField]
    private Rigidbody2D bulletRB;

    void Start()
    {
        bulletRB.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Bullet")
        {
            Destroy(gameObject);
        }
        
    }
}
