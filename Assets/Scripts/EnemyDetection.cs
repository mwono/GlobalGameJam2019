using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public GameObject player;
    public float detectionRadius = 5.0f;
    public bool alert = false;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.layer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(!alert && Vector2.Distance(this.transform.position, player.transform.position) < detectionRadius)
        {
            Vector3 start = this.transform.position;
            Vector3 direction = player.transform.position - this.transform.position;

            //Debug.DrawRay(start, direction, Color.red);
            RaycastHit2D los = Physics2D.Raycast(start, direction);

            //Debug.Log(los.collider.name);
            if (los.collider != null && los.collider.gameObject.CompareTag("Player"))
            {
                //Debug.Log("enemy spotted");
                alert = true;
                this.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
}
