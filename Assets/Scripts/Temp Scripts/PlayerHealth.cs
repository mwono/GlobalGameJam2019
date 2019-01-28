using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthold : MonoBehaviour {

	public float healthNum;
	public enemyDamage enemydamage;
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
       
    }



}
