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
        if (Input.GetButton("Fire1"))
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
        if (UI.GetComponent<UIManager>().manaBar.ReturnVal() > .4)
        {
            Instantiate(bulletPrefab, firePoint.position + new Vector3(0f, 0.2f, 0), firePoint.rotation);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Instantiate(bulletPrefab, firePoint.position + new Vector3(0f, -0.2f, 0), firePoint.rotation);
            //manaBar.GetComponent<ResourceBar>().Decrease(.4f);
            UI.GetComponent<UIManager>().manaBar.Decrease(.4f);
        }
        else { UI.GetComponent<UIManager>().PopText("Mana");}
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
