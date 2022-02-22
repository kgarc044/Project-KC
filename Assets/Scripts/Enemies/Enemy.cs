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


    void Awake()
    {
        ground = LayerMask.GetMask("Ground");
        rb = transform.GetComponent<Rigidbody2D>();
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
            ShowDamage(damage);
        }
        if (Health <= 0)
        {
            die();
        }
    }

    public void ShowDamage(int damage)
    {
        Instantiate(blood, transform.position, Quaternion.identity);
        var dmg = Instantiate(DamageText, transform.position, Quaternion.identity);
        dmg.GetComponent<TextMesh>().text = damage.ToString();
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

    public abstract void move();

    public abstract IEnumerator attack();

    public abstract bool detectPlayer();
}
