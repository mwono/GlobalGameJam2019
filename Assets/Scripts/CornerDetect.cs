﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerDetect : MonoBehaviour
{

    public bool touching = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        touching = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        touching = false;
    }
}
