﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences = new Queue<string>();
    public Queue<AudioClip> clips = new Queue<AudioClip>();
    public Text current;//Old text length: 450
    public Image textBox;//, portrait;
    public AudioManager am;
    //public Sprite kidSprite, dadSprite, noneSprite;
    public float textSpeed;
    public string scriptPath;
    public bool dialogueIsPaused = false;
    private string temp;
    // Start is called before the first frame update
    void Start()
    {
        foreach (AudioClip clip in am.clips)
        {
            clips.Enqueue(clip);
        }
        if (!scriptPath.Equals(""))
        {
            string[] t = System.IO.File.ReadAllLines(scriptPath);
            foreach (string s in t)
            {
                sentences.Enqueue(s);
            }
            StartCoroutine("TextScroll");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Hide"))
        {
            if (textBox.enabled)
            {
                current.enabled = false;
                textBox.enabled = false;
                StopCoroutine("TextScroll");
            } else
            {
                current.enabled = true;
                textBox.enabled = true;
                StartCoroutine("TextScroll");
            }
        }
        if (Input.GetButtonUp("Continue") && !scriptPath.Equals(""))
        {
            if (sentences.Count > 0)
            {
                current.enabled = true;
                StopCoroutine("TextScroll");
                StartCoroutine("TextScroll");
            }
            else
            {
                StopCoroutine("TextScroll");
                HideTextBox();
                //portrait.enabled = false;
                if (SceneManager.GetActiveScene().name.Equals("Cutscene1"))
                {
                    SceneManager.LoadScene("MVP");
                } else
                {
                    GameObject.Find("CutsceneManager").GetComponent<Cutscene2Manager>().enabled = true;
                }
            }
        }
    }

    public void LoadPath(string p)
    {
        string[] t = System.IO.File.ReadAllLines(p);
        for (int i = 0; i < t.Length; i++)
        {
            sentences.Enqueue(t[i]);
        }
        StopCoroutine("TextScroll");
        StartCoroutine("TextScroll");
    }

    IEnumerator TextScroll()
    {
        textBox.enabled = true;
        while (sentences.Count > 0)
        {
            temp = sentences.Dequeue();
            if (temp.Equals("BREAK"))
            {
                dialogueIsPaused = true;
                while (am.GetComponent<AudioSource>().isPlaying)
                {
                    yield return null;
                }
                HideTextBox();
                while (dialogueIsPaused)
                {
                    yield return null;
                }
                temp = sentences.Dequeue();
                textBox.enabled = true;
            }
            current.text = "";
            if (am.GetComponent<AudioSource>().isPlaying)
            {
                am.GetComponent<AudioSource>().Stop();
            }
            if (clips.Count > 0)
            {
                am.GetComponent<AudioSource>().PlayOneShot(clips.Dequeue());
            }
            for (int i = 0; i < temp.Length; i++)
            {
                current.text += temp[i];
                yield return new WaitForSeconds(textSpeed);
            }
            while (am.GetComponent<AudioSource>().isPlaying)
            {
                yield return null;
            }
            //yield return new WaitForSeconds(2f);
        }
        HideTextBox();
        //portrait.enabled = false;
        if (SceneManager.GetActiveScene().name.Equals("Cutscene1"))
        {
            SceneManager.LoadScene("MVP");
        }
        else
        {
            GameObject.Find("CutsceneManager").GetComponent<Cutscene2Manager>().enabled = true;
        }
    }

    void HideTextBox()
    {
        current.text = "";
        textBox.enabled = false;
    }
}