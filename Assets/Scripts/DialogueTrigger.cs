using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dm;
    public string path;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Player") && !path.Equals(""))
        {
            if (!dm.dialogueIsPaused) {
                dm.AddNewPath(path);
            }
            dm.dialogueIsPaused = false;
            this.gameObject.SetActive(false);
        }
    }
}
