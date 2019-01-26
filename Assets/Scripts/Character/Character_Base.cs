using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Base : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public float moveInput;

    //protected Health health;

    public Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void FixedUpdate()
    {

        moveInput = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(moveInput * speed, rigidbody.velocity.y);

    }
}
 