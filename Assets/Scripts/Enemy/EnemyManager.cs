using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float attDamage = 1;
    public float health = 2;
    public AudioClip deathSound;

    private bool isDead = false;
    private Animator animator;
    private AudioSource source;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(isDead == true)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            health = health -1;
            if(health <= 0)
            {
                //animator.SetBool("death", true);
                //source.PlayOneShot(deathSound, 2);
                isDead = true;
            }
        }
    }

    public float getDamage()
    {
        return attDamage;
    }
}
