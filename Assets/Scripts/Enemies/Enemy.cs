using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    // currently only used for bosses
    public string name;

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

    // If we're creating a boss, reference HUD instead of creating a local canvas
    public Canvas HealthCanvas;
    public Text BossName;
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
        Debug.Log("turn");
        transform.Rotate(0f, 180f, 0f);
        HealthCanvas.transform.right = new Vector3(1, 0, 0);
    }

    public void takeDamage(int damage, Vector3 hitlocation)
    {
        Health -= damage;
        if (DamageText && blood)
        {
            StartCoroutine(calculateDamage(damage, hitlocation));
        }
        if (Health <= 0)
        {
            die();
        }
    }

    // Show damage does blood effect, and number damage. Does not effect health bar UI.
    public IEnumerator ShowDamage(int damage, Vector3 hitlocation)
    {
        Instantiate(blood, hitlocation, Quaternion.identity);
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
        Destroy(HealthCanvas.gameObject);
        Destroy(gameObject);
    }


    // Control of the health bar UI
    public virtual void setHealthbar()
    {
        HealthCanvas.gameObject.SetActive(Health < maxHealth);
        calculateHealthbar();
    }

    public void calculateHealthbar()
    {
        hp.fillAmount = Health / maxHealth;

        if (hpeffect.fillAmount > hp.fillAmount)
        {
            hpeffect.fillAmount -= 0.005f;
        }
        else
        {
            hpeffect.fillAmount = hp.fillAmount;
        }
    }
    
    // Checks the front edge and floor for the enemy
    public void checkFloor()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);
        edge = !Physics2D.OverlapCircle(edgeCheck.position, checkRadius, ground);
    }

    public IEnumerator calculateDamage(int damage, Vector3 hitlocation)
    {
        damageTotal += damage;
        yield return new WaitForSeconds(.1f);
        StartCoroutine(ShowDamage(damageTotal, hitlocation));
        damageTotal = 0;
    }

    public abstract void move();

    public abstract IEnumerator attack();

    public abstract bool detectPlayer();
}
