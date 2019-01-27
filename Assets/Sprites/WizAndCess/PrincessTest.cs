using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            this.GetComponent<Animator>().SetInteger("frame", (this.GetComponent<Animator>().GetInteger("frame") + 1) % 3);
        }
    }
}
