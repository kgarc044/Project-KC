using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D bulletRB;

    void Start()
    {
        bulletRB.velocity = transform.right * speed;
    }
}
