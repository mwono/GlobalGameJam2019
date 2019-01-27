using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Death : EnemyManager
{
    //PlayerHealth playerHealth;
    public EnemyManager enemyManager;
    public Vector3 respawnPoint;
    //float Health;
    //float attDamage;

    private bool invincible = false;


    public void Update()
    {
        //Health = playerHealth.getHealth();
        //attDamage = enemyManager.getDamage();
        Debug.Log("Player health: " + healthNum);

        if (healthNum <= 0)
        {
            SceneManager.LoadScene("Game Over");

        }

    }

    /*public void noLives()
    {
        if (healthNum <= 0)
        {
            //SceneManager.LoadScene("Zach_Scene");
            Die();
        }
    }*/


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (!invincible)
        {
            if (other.gameObject.tag == "Enemy")
            {
                healthNum -= attDamage;
                //Debug.Log("Player health: " + healthNum);
                invincible = true;
                Invoke("restInvulnerability", 3);


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
