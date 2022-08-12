using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 50; // Placeholder damage for flintlock bullet

    [SerializeField]
    private Rigidbody2D bulletRB;

    void Start()
    {
        bulletRB.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            e.takeDamage(damage, this.transform.position);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
