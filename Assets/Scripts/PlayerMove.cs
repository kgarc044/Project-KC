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

    private bool facingRight = true;
    private bool isCasting = false;
    public bool gunSummoned;

    public GameObject[] gun;
    private GameObject getCurrentGun;
    private Transform playerTransform;

    [SerializeField]
    public GameObject UI;

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
    }

    private void FixedUpdate()
    {
        PMove();
        CheckForGround();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
            
        if (Input.GetKeyDown(KeyCode.Alpha1) && GameObject.FindGameObjectsWithTag("Gun").Length == 0)
        {
            if(!gunSummoned)
            {
                SetCurrentGun(gun[index]);
                StartCoroutine(CastingGunSpell());
                gunSummoned = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!gunSummoned)
            {
                SetCurrentGun(gun[index + 1]);
                StartCoroutine(CastingGunSpell());
                gunSummoned = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (!gunSummoned)
            {
                SetCurrentGun(gun[index + 2]);
                StartCoroutine(CastingGunSpell());
                gunSummoned = true;
            }
        }

    }

    void PMove()
    {
        moveX = Input.GetAxis("Horizontal");

        if (moveX < 0.0f && FacingRight)
        {
            this.FacingRight = !FacingRight;
            //Debug.Log(facingRight);
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
        if (UI.GetComponent<UIManager>().manaBar.ReturnVal() > .4)
        {
            UI.GetComponent<UIManager>().manaBar.Decrease(.4f);
            isCasting = true;
            SummonGun();
            yield return new WaitForSeconds(1f);
            isCasting = false;
        }
        else { UI.GetComponent<UIManager>().PopText("Mana"); }
    }

    void SummonGun()
    {
        if (facingRight)
        {
            Instantiate(GetCurrentGun(), playerTransform.position + new Vector3(1.5f, 0, 0), playerTransform.rotation);
        }
        else
        {
            Instantiate(GetCurrentGun(), playerTransform.position + new Vector3(-1.5f, 0, 0), playerTransform.rotation * new Quaternion(0,-180f,0,0));
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
