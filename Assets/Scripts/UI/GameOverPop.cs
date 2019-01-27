using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPop : MonoBehaviour
{
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            gameOver.SetActive(true);
        }
    }

}
