using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveX;
    public float checkRadius = 0.2f;

    public int playerSpeed = 15;
    public int playerJumpPower = 1250;
    public int index = 0;
    public Resource health = new Resource();
    public Resource mana = new Resource();

    private bool facingRight = true;
    private bool isCasting = false;
    public bool gunSummoned;

    public GameObject[] gun;
    private GameObject getCurrentGun;
    public GameObject instantiatedGun;
    private Transform playerTransform;

    [SerializeField]
    private GameObject UI;
    [SerializeField]
    private GameObject Player;

    public bool FacingRight
    {
        get
        {
            return facingRight;
        }
        set
        {
            facingRight = value;
        }
    }
    public bool isGrounded = true;

    [SerializeField]
    private Transform groundCheck;

    public LayerMask whatisGround;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        SetCurrentGun(gun[0]);

        UI = GameObject.Find("UIManager");
        Player = GameObject.Find("Player");

        health.SetResource(.5f);
        health.SetRegen(.00005f);
        mana.SetResource(.5f);
        mana.SetRegen(.0002f);
    }

    private void FixedUpdate()
    {
        PMove();
        CheckForGround();
    }
    // Update is called once per frame
    void Update()
    {
        if (!UIManager.gameIsPaused)
        {
            StopCoroutine(CastingGunSpell());

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) && GameObject.FindGameObjectsWithTag("Gun").Length == 0)
            {
                //Debug.Log("precast1");
                if (!gunSummoned)
                {
                    //Debug.Log("precast2");
                    SetCurrentGun(gun[index]);
                    StartCoroutine(CastingGunSpell());
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (!gunSummoned)
                {
                    SetCurrentGun(gun[index + 1]);
                    StartCoroutine(CastingGunSpell());
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (!gunSummoned)
                {
                    SetCurrentGun(gun[index + 2]);
                    StartCoroutine(CastingGunSpell());
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (!gunSummoned)
            {
                SetCurrentGun(gun[index + 3]);
                StartCoroutine(CastingGunSpell());
            }
        }

    }

    void PMove()
    {
        moveX = Input.GetAxis("Horizontal");

        if (moveX < 0.0f && FacingRight)
        {
            this.FacingRight = !FacingRight;
            Debug.Log(facingRight);
            transform.Rotate(0f, 180f, 0f);
        }

        if (moveX > 0.0f && !FacingRight)
        {
            this.FacingRight = !FacingRight;
            //Debug.Log(facingRight);
            transform.Rotate(0f, 180f, 0f);
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        //Jumping Code
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, playerJumpPower));
    }


    void CheckForGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisGround);
    }

    public IEnumerator CastingGunSpell()
    {
        if (mana.ReturnResource() > .4)
        {
            Debug.Log("gun cast");
            isCasting = true;
            SummonGun();
            mana.Decrease(.4f);
            yield return new WaitForSeconds(1f);
            isCasting = false;
            gunSummoned = true;
        }
        else 
        { 
            UI.GetComponent<UIManager>().PopText("Mana");
            Debug.Log("gun fail cast");
            gunSummoned = false;
        }
    }

    void SummonGun()
    {
        if (facingRight)
        {
            instantiatedGun = Instantiate(GetCurrentGun(), playerTransform.position + new Vector3(1.5f, 0, 0), playerTransform.rotation) as GameObject;
            //Instantiate(GetCurrentGun(), playerTransform.position + new Vector3(1.5f, 0, 0), playerTransform.rotation);
        }
        else
        {
            instantiatedGun = Instantiate(GetCurrentGun(), playerTransform.position + new Vector3(1.5f, 0, 0), playerTransform.rotation) as GameObject;
            //Instantiate(GetCurrentGun(), playerTransform.position + new Vector3(-1.5f, 0, 0), playerTransform.rotation * new Quaternion(0,-180f,0,0));
        }
    }

    public GameObject GetCurrentGun()
    {
        return getCurrentGun;
    }

    public void SetCurrentGun(GameObject gun)
    {
        getCurrentGun = gun;
    }
}
