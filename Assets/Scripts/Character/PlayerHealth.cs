using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public float healthNum;
	enemyDamage enemydamage;
    public float damage;

    public bool isDead;

	public void Start(){
		healthNum = 3;
        damage = enemydamage.getDamage(); 

	}

	public float getHealth(){
		return healthNum;
	}

	public float playerDamage(){
        healthNum -= damage;
		return healthNum;
	}

    //when the player is out of lives --> goes to game over screen
    void Update()
    {
        if(gameObject.transform.position.y < -7) 
        {
            isDead = true;
        }
        if (isDead == true)
        {
            StartCoroutine("Die");
        }
    }

    IEnumerator Die () 
    {
        SceneManager.LoadScene("Zach_Scene");
        yield return null;
    }

}
