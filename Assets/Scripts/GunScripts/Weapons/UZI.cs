using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UZI : GunBase
{
    public float cooldownTime = 0.2f;
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
    public float dashTime = 0;
    public float startDashTime = 0.1f;
    public float dashSpeed;
    public Animator animatorController;

    void Update()
    {
        if (Input.GetButton("Fire1") && !UIManager.gameIsPaused)
        {
            if (canShoot)
            {
                animatorController.SetBool("IsShooting", true);
                StartCoroutine(ShootDelay());
                

            }
        }
        else
        {
            animatorController.SetBool("IsShooting", false);
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
            GameObject projectileInstance;
            
            projectileInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            projectileInstance.GetComponent<Rigidbody2D>().
            AddForce(firePoint.up + new Vector3(0f, Random.Range(minY, maxY), 0f));
            

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
        if (player.mana.ReturnResource() > .1)
        {
            player.mana.Decrease(.1f);
            //player.playerSpeed = player.playerSpeed * 10;
            //playerRB.bodyType = RigidbodyType2D.Kinematic;
            //playerRB.velocity = playerTransform.right * 100000f;
            playerRB.transform.position = Vector3.Lerp(playerRB.transform.position, playerRB.transform.position
              + playerRB.transform.right * 2f , 1);
            



           ammoTotal = 10;
        }/**/

        StartCoroutine(SpecialDelay());
    }

    public IEnumerator SpecialDelay()
    {
        yield return new WaitForSeconds(0.1f);
        player.playerSpeed = 5;
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
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

    }
}
