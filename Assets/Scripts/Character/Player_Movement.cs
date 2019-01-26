using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : Character_Base
{

    public float speed;
    public float jumpForce;
    public float moveInput;



    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {

        moveInput = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(moveInput * speed, rigidbody.velocity.y);

    }


}