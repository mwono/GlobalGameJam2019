using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrack : MonoBehaviour
{
    public Transform playerTrans;
    public float speed = 3;

    private GameObject player;
    private float timer;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerTrans = player.GetComponent<Transform>();
        timer = 0;

        Vector2 playerPos = new Vector2(playerTrans.position.x, playerTrans.position.y + 1);

        transform.rotation = Quaternion.LookRotation(playerPos);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        timer += 1 * Time.deltaTime;
        if ( timer >= 8)
        {
            Destroy(this.gameObject);
        }
    }
}
