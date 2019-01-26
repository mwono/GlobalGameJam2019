using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : Character_Base
{

    public float speed;
    public float jumpForce;
    public float moveInput;

    public float checkRadius;
    public Transform groundCheck;
    public LayerMask isMoving;
    public bool isGrounded;


    //private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isGrounded == true)
        {
            //Debug.Log("On moving platform");

        }
    }
    void FixedUpdate()
    {

        moveInput = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(moveInput * speed, rigidbody.velocity.y);

        //moving platform
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, isMoving);

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.transform.tag == ("Moving Platform") && isGrounded)
        {
            //GetComponent<Rigidbody2D>().isKinematic = true;
            this.transform.parent = coll.transform;
        }

    }
    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.transform.tag == ("Moving Platform"))
        {
            //GetComponent<Rigidbody2D>().isKinematic = true;
            this.transform.parent = null;
        }
    }


}

//rigidbody.velocity = new Vector2(moveInput * speed, rigidbody.velocity.y);