using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    public float Speed;
    public float maxHealth;
    public float Health;
    public GameObject DamageText;
    public GameObject blood;
    public GameObject dust;

    public float checkRadius = 0.01f;
    public Transform edgeCheck;
    public Transform groundCheck;
    public Transform front;
    [HideInInspector] public LayerMask ground;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public bool isGrounded;
    [HideInInspector] public bool edge;

    public Canvas HealthCanvas;
    public Image hp; // This is the red hp image
    public Image hpeffect; // This is used to create the white health effect

    private int damageTotal = 0;
    private GameObject dmgtext;


    void Awake()
    {
        //Sets ground on awake. Could be changed so that ground is just set in inspector
        ground = LayerMask.GetMask("Ground");
        //Sets the rigidbody since it will be used frequently. Could be changed so that we drag in the rigidbody through inspector
        rb = transform.GetComponent<Rigidbody2D>();
        //Sets the health bar to always look at the front direction
        HealthCanvas.transform.right = new Vector3(1, 0, 0);
    }

    public void turn()
    {
        transform.Rotate(0f, 180f, 0f);
        HealthCanvas.transform.right = new Vector3(1, 0, 0);
    }

    public void takeDamage(int damage)
    {
        Health -= damage;
        if (DamageText && blood)
        {
            StartCoroutine(calculateDamage(damage));
        }
        if (Health <= 0)
        {
            die();
        }
    }

    public IEnumerator ShowDamage(int damage)
    {
        Instantiate(blood, transform.position, Quaternion.identity);
        if (dmgtext == null)
        {
            dmgtext = Instantiate(DamageText, transform.position, Quaternion.identity);
            dmgtext.GetComponent<TextMesh>().text = damage.ToString();
            yield return new WaitForSeconds(.01f);
            dmgtext = null;
        }
    }

    public void die()
    {
        Destroy(gameObject);
    }

    public void setHealthbar()
    {
        HealthCanvas.gameObject.SetActive(Health < maxHealth);

        hp.fillAmount = Health / maxHealth;

        if(hpeffect.fillAmount > hp.fillAmount)
        {
            hpeffect.fillAmount -= 0.01f;
        }
        else
        {
            hpeffect.fillAmount = hp.fillAmount;
        }

    }

    public void checkFloor()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);
        edge = !Physics2D.OverlapCircle(edgeCheck.position, checkRadius, ground);
    }

    public IEnumerator calculateDamage(int damage)
    {
        damageTotal += damage;
        yield return new WaitForSeconds(.1f);
        StartCoroutine(ShowDamage(damageTotal));
        damageTotal = 0;
    }

    public abstract void move();

    public abstract IEnumerator attack();

    public abstract bool detectPlayer();
}
