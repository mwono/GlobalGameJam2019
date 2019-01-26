using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public float healthNum;
	enemyDamage enemydamage;
    public float damageEnemy;
    public float damageFall;
    public float damageLava;



    public void Start(){
		healthNum = 3;
        damageEnemy = enemydamage.getDamage();

	}

	public float getHealth(){
		return healthNum;
	}

	public float enemyDamage(){
        healthNum -= damageEnemy;
		return healthNum;
	}

    //when the player is out of lives --> goes back to a specific point

	public float damageByFalling(){ //is there falling?
        damageFall = 1f;
        healthNum -= damageFall;
        return healthNum;

    }

    public float damageByLava(){ 
        damageLava = 1f;
        healthNum -= damageLava;
        return healthNum;

    }




}
