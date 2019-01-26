using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public Sprite yellowFlower;
    public Sprite greenTree;
    private SpriteRenderer checkpointSpriteRenderer;
    public bool checkpointReached;


    // Start is called before the first frame update
    void Start()
    {
        checkpointSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D checkP)
    {
        if(checkP.tag == "Player")
        {
            checkpointSpriteRenderer.sprite = greenTree;
            checkpointReached = true;
        }
    }
}
