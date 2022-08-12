using System.Collections;
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
    public Animator shotgunAnim;

    public int bulletCount;
    public float maxY;
    public float minY;


    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !UIManager.gameIsPaused)
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
            BulletSpread(minY, maxY);
            
            ammoTotal--;
        }
        else
        {
            ThrowGun();
        }
    }

    public void BulletSpread(float minY, float maxY)
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject projectileInstance;
            projectileInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            projectileInstance.GetComponent<Rigidbody2D>().
            AddForce(-firePoint.up + new Vector3(0f, Random.Range(minY, maxY), 0f));
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
        if (player.mana.ReturnResource() > .1)
        {
            player.mana.Decrease(.1f);
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));
            this.transform.Rotate(0, 0, -90f);
            StartCoroutine(SpecialDelay());
        }
    }

    public IEnumerator SpecialDelay()
    {
        yield return new WaitForSeconds(0.5f);
        BulletSpread(270, -270);
        this.transform.Rotate(0, 0, 90f);
    }


    public override void ThrowGun()
    {
        outOfAmmo = true;
        gunCollider.enabled = true;
        ReturnGunStatus();
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().AddForce(transform.right * 1000f);
        Debug.Log("*Wizard throws gun*");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
