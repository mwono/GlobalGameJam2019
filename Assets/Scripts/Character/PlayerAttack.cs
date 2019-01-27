using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    EnemyManager enemyManager; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void onTriggerEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyManager.takeDamage(); 

        }
    }




}
