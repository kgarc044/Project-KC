using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveX;
    public float checkRadius = 0.2f;

    public int playerSpeed = 15;
    public int playerJumpPower = 1250;

    private bool facingRight = true;
    private bool isCasting = false;

    public GameObject gun;
    private Transform playerTransform;

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
            
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(CastingGunSpell());
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
        isCasting = true;
        SummonGun();
        yield return new WaitForSeconds(1f);
        isCasting = false;
    }

    void SummonGun()
    {
        if (facingRight)
        {
            Instantiate(gun, playerTransform.position + new Vector3(1.5f, 0, 0), playerTransform.rotation);
        }
        else
        {
            Instantiate(gun, playerTransform.position + new Vector3(-1.5f, 0, 0), playerTransform.rotation * new Quaternion(0,-180f,0,0));
        }
    }
}
