using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutscene2Manager : MonoBehaviour
{
    public Image im1, im2, im3;
    public GameObject princess, castleIntBG;
    // Start is called before the first frame update
    void Start()
    {
        im3.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (im1.enabled)
        //{
        //    StartCoroutine("im1Fade");
        //}
        //else if (im2.enabled)
        //{
        //    StartCoroutine("im2Fade");
        //}
        //else if (im3.enabled)
        //{
        //    StartCoroutine("im3Fade");
        //}
    }

    IEnumerator im1Fade()
    {
        im1.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);
        im2.enabled = true;
    }

    IEnumerator im2Fade()
    {
        im2.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);
        im3.enabled = true;
    }

    IEnumerator im3Fade()
    {
        im3.CrossFadeAlpha(0f, 1.5f, false);
        yield return new WaitForSeconds(1f);
        princess.SetActive(false);
        castleIntBG.SetActive(false);
    }
}
