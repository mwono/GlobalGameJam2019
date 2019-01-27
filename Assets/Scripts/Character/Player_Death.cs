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
    public Animator animator;

    public GameObject gameover;
    void Start()
    {
        //animator = GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        //Health = playerHealth.getHealth();
        //attDamage = enemyManager.getDamage();
        //Debug.Log("Player health: " + healthNum);

        if (healthNum <= 0)
        {
            //animator.SetBool("isDead", true);
            StartCoroutine("GameDelay");
            //SceneManager.LoadScene("Game Over");

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
                //Debug.Log("Damage Detected");
                healthNum -= attDamage;
                //Debug.Log("Player health: " + healthNum);
                invincible = true;
                Invoke("restInvulnerability", 3);


            }
        }

        if(other.tag == "Death Zone")
        {
            //animator.SetBool("isDead", true);
            healthNum -= 0.5f;
            StartCoroutine("Delay");
            //transform.position = respawnPoint;

        }

        if(other.tag == "Checkpoint")
        {
            respawnPoint = other.transform.position;
            //yield return new WaitForSeconds(1);

        }
    }

    void restInvulnerability()
    {
        invincible = false;
    }

    public IEnumerator Delay()
    {
        animator.SetBool("isDead", true);
        //healthNum -= 0.5f;
        yield return new WaitForSeconds(1.3f);
        //WaitForSeconds(3);
        animator.SetBool("isDead", false);
        transform.position = respawnPoint;
        //print(Time.time);
    }

    public IEnumerator GameDelay()
    {
        animator.SetBool("isDead", true);
        //healthNum -= 0.5f;
        yield return new WaitForSeconds(1.3f);
        //WaitForSeconds(3);
        //animator.SetBool("isDead", false);
        //transform.position = respawnPoint;
        gameover.SetActive(true);
        Time.timeScale = 0f;
    }
}
