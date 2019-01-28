using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class RestartLevel : MonoBehaviour

{

    Scene currentScene;
    string sceneName;
    public GameObject gameOver;
    

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        sceneName = currentScene.name; 
        if (Input.GetKeyDown(KeyCode.J))
        {
            gameOver.SetActive(true);
        }
    }


    public void restartLevel()
    {
       if(sceneName == "MVP")
        {
            SceneManager.LoadScene("MVP");
            gameOver.SetActive(false); 
        }
       /*if(sceneName == "Level-2")
        {
            SceneManager.LoadScene("Level-2");
        }
        if (sceneName == "Level-3")
        {
            SceneManager.LoadScene("Level-3"); 
        }*/


    }


}
