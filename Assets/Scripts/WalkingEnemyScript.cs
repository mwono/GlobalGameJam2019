﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyScript : MonoBehaviour
{

    public float speed = 3.0f;

    private bool turning = false;
    private float turnTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed, 0.0f);


        if (!turning)
        {
            foreach (CornerDetect test in GetComponentsInChildren<CornerDetect>())
            {
                if (!test.touching)
                {
                    speed *= -1;
                    turning = true;
                    turnTime = Time.time;
                }
            }
        }

        else if (turning && Time.time - turnTime > 0.5)
            turning = false;
    }
}
