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
        if (Input.GetButton("Fire1") && !UIManager.gameIsPaused)
        {
            if (canShoot)
            {
                StartCoroutine(ShootDelay());
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && !UIManager.gameIsPaused)
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
        if (player.mana.ReturnResource() > .4)
        {
            Instantiate(bulletPrefab, firePoint.position + new Vector3(0f, 0.2f, 0), firePoint.rotation);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Instantiate(bulletPrefab, firePoint.position + new Vector3(0f, -0.2f, 0), firePoint.rotation);
            player.mana.Decrease(.4f);
        }
        else { UI.GetComponent<UIManager>().PopText("Mana");}
    }

    public override void ThrowGun()
    {
        outOfAmmo = true;
        gunCollider.enabled = true;
        gunSpawned = false;
        ReturnGunStatus();
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().AddForce(transform.right * 1000f);
        Debug.Log("*Wizard throws gun*");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        
    }
}
