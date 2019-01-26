using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences = new Queue<string>();
    public Text current;
    public Image textBox;
    public float textSpeed;
    public string scriptPath;
    private string temp;
    // Start is called before the first frame update
    void Start()
    {
        string[] t = System.IO.File.ReadAllLines(scriptPath);
        for (int i = 0; i < t.Length; i++)
        {
            sentences.Enqueue(t[i]);
        }
        StartCoroutine("TextScroll");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Continue"))
        {
            if (sentences.Count > 0)
            {
                StopCoroutine("TextScroll");
                StartCoroutine("TextScroll");
            } else
            {
                current.text = "";
                textBox.enabled = false;
                //MoveScene
            }
        }
    }

    IEnumerator TextScroll()
    {
        if (textBox.enabled == false)
        {
            textBox.enabled = true;
        }
        while (sentences.Count > 0)
        {
            temp = sentences.Dequeue();
            current.text = "";
            for (int i = 0; i < temp.Length; i++)
            {
                current.text += temp[i];
                yield return new WaitForSeconds(textSpeed);
            }
            yield return new WaitForSeconds(4f);
        }
        current.text = "";
        textBox.enabled = false;
        //MoveScene
    }
}
