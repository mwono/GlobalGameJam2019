using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public float healthNum;
	enemyDamage enemydamage;
    public float damage; 


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



}
