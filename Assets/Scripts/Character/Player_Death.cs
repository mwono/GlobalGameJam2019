using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Death : PlayerHealth
{
    public Vector3 respawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Death Zone")
        {
            transform.position = respawnPoint;
        }

        if(other.tag == "Checkpoint")
        {
            respawnPoint = other.transform.position;
        }
    }

}
