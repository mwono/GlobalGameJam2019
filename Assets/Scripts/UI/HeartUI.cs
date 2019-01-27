using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    public float health;
    public int heartNum;
    

    public Image[] hearts;

    private void Update()
    {

        if (health == 2.5f)
        {
            hearts[2].fillAmount = .5f;
        }
        else if (health == 2.0f)
        {
            hearts[2].fillAmount = 0f;
            

        }
        else if (health==1.5f)
        {
            hearts[2].fillAmount = 0f;
            hearts[1].fillAmount = .5f;

        }
        else if (health == 1f)
        {
            hearts[2].fillAmount = 0f;
            hearts[1].fillAmount = 0f;

        }
        else if (health == .5f)
        {
            hearts[2].fillAmount = 0f;
            hearts[1].fillAmount = 0f;
            hearts[0].fillAmount = .5f;

        }
        else if( health == 0f)
        {
            hearts[2].fillAmount = 0f;
            hearts[1].fillAmount = 0f;
            hearts[0].fillAmount = 0f;

        }


        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            health -= .5f;
        }
    }

    private void ChangeHearts(float currentHealth)
    {
        for(int i = 0; i<heartNum; ++i)
        {
            
        }
    }
}
