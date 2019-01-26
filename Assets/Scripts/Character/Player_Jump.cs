using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : Character_Base
{
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int doubleJump;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true)
        {
            doubleJump = 1;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && doubleJump > 0)
        {
            //GetComponent<Rigidbody2D>(Vector2.up * jumpForce);
            rigidbody.velocity = Vector2.up * jumpForce;
            doubleJump--;
        }

    }


    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }
}
