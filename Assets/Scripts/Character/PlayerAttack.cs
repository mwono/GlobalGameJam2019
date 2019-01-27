using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    
    EnemyManager enemyManager; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }



    public void onTriggerEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyManager.takeDamage(); 

        }
    }




}
