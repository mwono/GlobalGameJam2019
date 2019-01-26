using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    public GameObject follow;
    private Transform parent;
    private float x;
    private float y;
    
    public float minX = 0.0f;
    public float maxX = 0.0f;
    public float minY = 0.0f;
    public float maxY = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        parent = follow.transform;
    }

    // Update is called once per frame
    void Update()
    {
        x = parent.position.x;
        y = parent.position.y;

        this.transform.position = new Vector2(Mathf.Clamp(x, minX, maxX), Mathf.Clamp(y, minY, maxY));
    }
}
