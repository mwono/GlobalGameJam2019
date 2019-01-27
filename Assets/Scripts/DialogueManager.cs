using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if (!scriptPath.Equals(""))
        {
            string[] t = System.IO.File.ReadAllLines(scriptPath);
            foreach (string s in t)
            {
                sentences.Enqueue(s);
            }
            foreach (AudioClip clip in am.clips)
            {
                clips.Enqueue(clip);
            }
            StartCoroutine("TextScroll");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Continue") && !scriptPath.Equals(""))
        {
            if (sentences.Count > 0)
            {
                StopCoroutine("TextScroll");
                StartCoroutine("TextScroll");
            } else
            {
                StopCoroutine("TextScroll");
                current.text = "";
                textBox.enabled = false;
                //portrait.enabled = false;
                //MoveScene
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
        StartCoroutine("TextScroll");
    }

    IEnumerator TextScroll()
    {
        textBox.enabled = true;
        while (sentences.Count > 0)
        {
            temp = sentences.Dequeue();
            switch (temp)
            {
                //case "(K)":
                //    {
                //        portrait.sprite = kidSprite;
                //        current.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 385);
                //        current.GetComponent<RectTransform>().anchoredPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, 0));
                //        //current.GetComponent<RectTransform>().SetPositionAndRotation(Camera.main.WorldToScreenPoint(new Vector3(35, 0))
                //        //    , new Quaternion());
                //        temp = sentences.Dequeue();
                //        break;
                //    }
                //case "(D)":
                //    {
                //        portrait.sprite = dadSprite;
                //        current.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 385);
                //        current.GetComponent<RectTransform>().anchoredPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, 0));
                //        //current.GetComponent<RectTransform>().SetPositionAndRotation(Camera.main.WorldToScreenPoint(new Vector3(35, 0))
                //        //    , new Quaternion());
                //        temp = sentences.Dequeue();
                //        break;
                //    }
                //case "(N)":
                //    {
                //        portrait.sprite = noneSprite;
                //        current.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 450);
                //        current.GetComponent<RectTransform>().anchoredPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, 0));
                //        //current.GetComponent<RectTransform>().SetPositionAndRotation(Camera.main.WorldToScreenPoint(new Vector3(0, 0))
                //        //    , new Quaternion());
                //        temp = sentences.Dequeue();
                //        break;
                //    }
                case "BREAK":
                    {
                        dialogueIsPaused = true;
                        while (dialogueIsPaused)
                        {
                            yield return null;
                        }
                        temp = sentences.Dequeue();
                        break;
                    }
            }
            current.text = "";
            if (am.GetComponent<AudioSource>().isPlaying)
            {
                am.GetComponent<AudioSource>().Stop();
            }
            am.GetComponent<AudioSource>().PlayOneShot(clips.Dequeue());
            for (int i = 0; i < temp.Length; i++)
            {
                current.text += temp[i];
                yield return new WaitForSeconds(textSpeed);
            }
            yield return new WaitForSeconds(2f);
        }
        current.text = "";
        textBox.enabled = false;
        //portrait.enabled = false;
        //MoveScene
    }
}
