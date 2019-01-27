using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Death : EnemyManager
{
    PlayerHealth playerHealth;
    public Vector3 respawnPoint;
    float Health;

    public void Start()
    {
        if(healthNum > 0)
        {
            Debug.Log(healthNum);
        }

    }


    public void Update()
    {
        Health = playerHealth.getHealth();

    }

    public void noLives()
    {
        if(Health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            healthNum -= attDamage;

        }

        if(other.tag == "Death Zone")
        {
            healthNum -= 0.5f;
            transform.position = respawnPoint;

        }

        if(other.tag == "Checkpoint")
        {
            respawnPoint = other.transform.position;
        }
    }

}
