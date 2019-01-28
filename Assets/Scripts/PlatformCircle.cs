using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCircle : MonoBehaviour
{
    public float xRadius = 1.0f;
    public float yRadius = 1.0f;
    public float timeScaleX = 1.0f;
    public float timeScaleY = 1.0f;
    public bool clockwise = true;
    
    private Vector3 xPath;
    private Vector3 yPath;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position + new Vector3(xRadius / 2, yRadius / 2, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(clockwise)
            this.transform.position = startPos + new Vector3(Mathf.Sin(Time.time * timeScaleX) * xRadius / 2, Mathf.Cos(Time.time * timeScaleY) * yRadius / 2, 0.0f);
        else
            this.transform.position = startPos - new Vector3(Mathf.Cos(Time.time * timeScaleX) * xRadius / 2, Mathf.Sin(Time.time * timeScaleY) * yRadius / 2, 0.0f);
    }
}
