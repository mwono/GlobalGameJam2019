using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : Player_Movement
{
    //private bool isGrounded;
    //public Transform groundCheck;
    //public float checkRadius;
    public LayerMask whatIsGround;

    public Animator animator;

    public int doubleJump;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponentInChildren<Animator>();
        //animator.SetBool("isJumping", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true)
        {
            doubleJump = 1;
            animator.SetBool("isJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && doubleJump > 0)
        {
            isGrounded = false;
            this.transform.SetParent(null);
            //GetComponent<Rigidbody2D>(Vector2.up * jumpForce);
            rigidbody.velocity = Vector2.up * jumpForce;
            doubleJump--;

        }

        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            //Debug.Log("jump");
            animator.SetBool("isJumping", true);

        }
        else
        {
            animator.SetBool("isJumping", false);
        }

    }


    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }
}
