using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuSelect : MonoBehaviour
{

    public void LoadGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(int number)
    {
        SceneManager.LoadScene("Level-" + number);
    }
}
