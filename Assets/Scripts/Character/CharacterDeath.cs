using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class CharacterDeath : MonoBehaviour
{
    PlayerHealth playerHealth;
    float noHealth; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        noHealth = playerHealth.getHealth(); 
    }

    public void notLives(){
        if(noHealth <= 0)
        {
            SceneManager.LoadScene("Game Over"); 
        }

    }






}
