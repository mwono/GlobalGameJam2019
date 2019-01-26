using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour{

    public Rigidbody2D rbody;
    public float moveForce = 10;
    public float jumpForce = 30;
    Vector2 moveHorizontalVector;
    Vector2 startPos;
    float movements;
    PlayerHealth healthPlayer;
    float startHealth;
    bool touchingPlatform; 


    public void Start(){
        startPos = transform.position;
        touchingPlatform = true; 
        //startHealth = healthPlayer.getHealth(); 
       
    }

    public void Update(){
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        movements = Input.GetAxis("Horizontal");
        if (movements > -13)
            transform.localScale = new Vector3(1f, 1f, 1f);
        if (movements < -13)
            transform.localScale = new Vector3(-1f, 1f, 1f);

        if (transform.position.y < -10f){   //change to the position where people fall
            //transform.position = startPos; //change to the position of checkpoint 
            //add a part to deduct health for falling off the ledge
        }

    }

    public void Awake(){

	}

    void FixedUpdate()
    {

        moveHorizontalVector = new Vector2(movements * moveForce, 0);
        rbody.AddForce(moveHorizontalVector);

        if (Input.GetButtonDown("Jump") && touchingPlatform == true)
        {
            rbody.AddForce(new Vector2(0, jumpForce * moveForce));
            touchingPlatform = false;


        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Colliding with an object tagged as: " + other.gameObject.tag);

        if (other.gameObject.CompareTag("platform"))
        {
            touchingPlatform = true;
        }
        /*if (other.gameObject.CompareTag("Enemy"))
        {

        }*/
    }



}
