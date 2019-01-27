using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public GameObject player;
    public float speed = 3.0f;
    public float chargeInterval = 5.0f;

    private Rigidbody2D rb;
    private bool angry = false;
    private float lastCharged = 0.0f;

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
            rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, speed * -3, speed * 3), Mathf.Clamp(rb.velocity.y, speed * -3, speed * 3), 0.0f);

            if (Vector3.Distance(player.transform.position, this.transform.position) > GetComponent<EnemyDetection>().detectionRadius * 1.5)
            {
                rb.AddForce((player.transform.position - this.transform.position) * speed);
            }

            if(Time.time - lastCharged > chargeInterval || Vector3.Distance(player.transform.position, this.transform.position) > GetComponent<EnemyDetection>().detectionRadius * 3.0)
            {
                lastCharged = Time.time;

                rb.velocity = Vector3.RotateTowards(rb.velocity, (player.transform.position - this.transform.position) * speed, 180f / (2 * Mathf.PI), Mathf.Infinity);
            }
        }
        else if(GetComponent<EnemyDetection>().alert)
        {
            angry = true;
        }
    }
}
