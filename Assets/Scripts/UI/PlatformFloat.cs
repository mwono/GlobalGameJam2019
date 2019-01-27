using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFloat : MonoBehaviour
{
    public float xDis = 0.0f;
    public float yDis = 1.0f;
    public float timeScale = 1.0f;

    private Vector3 direction;
    private Vector3 startPos;


    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(xDis / 2, yDis / 2, 0.0f);
        startPos = this.transform.position + new Vector3(xDis / 2, yDis / 2, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = startPos - Mathf.Cos(Time.time * timeScale) * direction;
    }
}
