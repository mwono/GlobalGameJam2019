using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene2Manager : MonoBehaviour
{
    public Image im1, im2, im3;
    public GameObject princess, castleIntBG, player;
    // Start is called before the first frame update
    void Start()
    {
        princess.SetActive(false);
        castleIntBG.SetActive(false);
        player.SetActive(false);
        StartCoroutine("Fade");
    }

    IEnumerator Fade()
    {
        im1.enabled = true;
        im2.enabled = true;
        im3.enabled = true;
        im1.CrossFadeAlpha(0f, 3f, false);
        yield return new WaitForSeconds(3f);
        im1.enabled = false;
        im2.CrossFadeAlpha(0f, 3f, false);
        yield return new WaitForSeconds(3f);
        im2.enabled = false;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("credits");
    }
}
