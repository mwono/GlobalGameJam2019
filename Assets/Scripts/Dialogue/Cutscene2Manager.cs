using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutscene2Manager : MonoBehaviour
{
    public Image im1, im2, im3;
    // Start is called before the first frame update
    void Start()
    {
        im1.enabled = true;
        im2.enabled = true;
        im3.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("im1Fade");
        StartCoroutine("im2Fade");
        StartCoroutine("im3Fade");
    }

    IEnumerator im1Fade()
    {
        im1.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);
    }

    IEnumerator im2Fade()
    {
        im2.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);
    }

    IEnumerator im3Fade()
    {
        im3.CrossFadeAlpha(0f, 1.5f, false);
        yield return new WaitForSeconds(1.5f);
    }
}
