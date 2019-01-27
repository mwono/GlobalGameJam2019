using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public GameObject player;
    public float speed = 3.0f;

    private Rigidbody2D rb;
    private bool angry = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(angry)
        {
            rb.AddForce((player.transform.position - this.transform.position) * speed);
        }
        else if(GetComponent<EnemyDetection>().alert)
        {
            angry = true;
        }
    }
}
