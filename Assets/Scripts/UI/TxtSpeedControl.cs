using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TxtSpeedControl : MonoBehaviour
{
    public Text textSpeed;
    private float speed = .03f;
    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Start()
    {
        Scene current = SceneManager.GetActiveScene();
        if (current.name.Equals("MVP") || current.name.Equals("Cutscene1"))
        {
            GameObject.Find("DialogueCanvas").GetComponentInChildren<DialogueManager>().textSpeed = speed;
        }
    }

    public void SlowSpeed()
    {
        speed = .05f;
        textSpeed.text = "Slow";
    }

    public void FastSpeed()
    {
        speed = .03f;
        textSpeed.text = "Fast";
    }
}
