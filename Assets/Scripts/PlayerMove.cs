using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveX;
    public float checkRadius = 0.2f;

    public int playerSpeed = 15;
    public int playerJumpPower = 1250;

    public bool FacingRight = true;
    public bool isGrounded = true;

    [SerializeField]
    private Transform groundCheck;

    public LayerMask whatisGround;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    void PMove()
    {
        moveX = Input.GetAxis("Horizontal");

        if (moveX < 0.0f && FacingRight)
        {
            FacingRight = !FacingRight;
            transform.Rotate(0f, 180f, 0f);
        }

        if (moveX > 0.0f && !FacingRight)
        {
            FacingRight = !FacingRight;
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
}
