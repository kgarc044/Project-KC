using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlintLockPistol : GunBase
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public override void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

}
