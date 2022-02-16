﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawedShotGun : GunBase
{
    public float cooldownTime = 1f;
    public bool canShoot = true;

    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Collider2D gunCollider;
    public int bulletCount;
    public float maxY;
    public float minY;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (canShoot)
            {
                StartCoroutine(ShootDelay());
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Special();
        }
    }

    public override void Shoot()
    {
        if (ammoTotal > 0)
        {
            for(int i = 0; i < bulletCount; i++)
            {
                GameObject projectileInstance;
                projectileInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                projectileInstance.GetComponent<Rigidbody2D>().
                    AddForce(firePoint.up + new Vector3(0f, Random.Range(minY, maxY), 0f));
            }
            
            ammoTotal--;
        }
        else
        {
            ThrowGun();
        }
    }

    public IEnumerator ShootDelay()
    {
        Shoot();
        canShoot = false;
        yield return new WaitForSeconds(cooldownTime);
        canShoot = true;
    }

    public override void Special()
    {
        Instantiate(bulletPrefab, firePoint.position + new Vector3(0f, 0.2f, 0), firePoint.rotation);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(bulletPrefab, firePoint.position + new Vector3(0f, -0.2f, 0), firePoint.rotation);
    }

    public override void ThrowGun()
    {
        outOfAmmo = true;
        gunCollider.enabled = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().AddForce(transform.right * 1000f);
        Debug.Log("*Wizard throws gun*");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
