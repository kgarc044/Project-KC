using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlintLockPistol : GunBase
{
    public float cooldownTime = 1f;
    public bool canShoot = true;

    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Collider2D gunCollider;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (canShoot)
            {
                StartCoroutine(ShootDelay());
            }
        }
    }

    public override void Shoot()
    {
        if (ammoTotal > 0)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
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
        throw new System.NotImplementedException();
    }

    public override void ThrowGun()
    {
        outOfAmmo = true;
        gunCollider.enabled = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().AddForce(transform.right * 1000f);
        Debug.Log("*Wizard throws gun*");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
