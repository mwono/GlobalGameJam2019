using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Death : EnemyManager
{
    //PlayerHealth playerHealth;
    //EnemyManager enemyManager;
    public Vector3 respawnPoint;
    //float Health;
    //float attDamage;

    private bool invincible = false;

    public void Start()
    {
        if(healthNum > 0)
        {
            Debug.Log(healthNum);
        }

    }


    public void Update()
    {
        //Health = playerHealth.getHealth();
        //attDamage = enemyManager.getDamage();
        if(healthNum >= 0)
        {
            Debug.Log(healthNum);
        }


    }

    public void noLives()
    {
        if(healthNum <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!invincible)
        {
            if (other.gameObject.tag == "Enemy")
            {
                healthNum -= attDamage;
                invincible = true;
                Invoke("restInvulnerability", 3);
                //need invinsibility timer here

            }
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

    void restInvulnerability()
    {
        invincible = false;
    }

}
