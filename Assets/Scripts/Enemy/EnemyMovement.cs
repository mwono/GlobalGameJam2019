using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float xDis = 1.0f;
    public float yDis = 0.0f;
    public float timeScale = 7.0f;

    private Vector3 direction;
    private Vector3 startPos;
    private Animator animator;
    private Rigidbody2D rg;
    private float timer;

    private bool facingRight = true;

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        //animator.SetBool("Walking", true);

        direction = new Vector3(xDis / 2, yDis / 2, 0.0f);
        startPos = this.transform.position + new Vector3(xDis / 2, yDis / 2, 0.0f);
        timer = 0;
    }

    void Update()
    {
        this.transform.position = startPos - Mathf.Cos(Time.time * timeScale) * direction;

        if (Mathf.Cos(Time.time * timeScale) > 0)
        {
            //transform.localScale = new Vector3(1, 1, 1);
            transform.localScale -= new Vector3(transform.localScale.x * 2, 0, 0);
            facingRight = true;

        } else
        {
            //transform.localScale = new Vector3(-1, 1, 1);
            transform.localScale -= new Vector3(transform.localScale.x * 2, 0, 0);
            facingRight = false;
        }

        timer += (1 * Time.deltaTime);
    }
}
