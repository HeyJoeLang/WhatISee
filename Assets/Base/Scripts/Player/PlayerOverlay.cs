using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOverlay : MonoBehaviour
{
    public MeshRenderer[] _children;

    public bool isActive;
    public float rate = 1;
    public float currAlpha = 0;

    public float delayFadeout = 2;

    //public Transform fallenPlacement;
    //public float headAdjust = 0.5f;

    public bool isDebug;
    private bool hasTriggered;


    #region Pubilc
    public void ActiveOverlay()
    {
        // Just in case the Player has fallen again
        StopCoroutine(Co_FadeOut());

        isActive = true;
        currAlpha = 1;
        SetAlpha(currAlpha);
    }

    public void TriggerFadeout()
    {
        StartCoroutine(Co_FadeOut());
    }

    public void TriggerFadeIn()
    {
        StartCoroutine(Co_FadeIn());
    }
    #endregion
    #region Priority

    // Use this for initialization
    void Start ()
    {
        hasTriggered = isActive;
        currAlpha = (isActive)? 1 : 0;
        SetAlpha(currAlpha);
        StartCoroutine(Co_FadeOut());
    }

    // Update is called once per frame
    void Update()
    {
        if(isDebug && isActive != hasTriggered)
        {
            hasTriggered = isActive;
            StartCoroutine(((isActive) ? Co_FadeIn() : Co_FadeOut()));
        }
        
	}

    private void SetAlpha(float alpha)
    {
        foreach (MeshRenderer child in _children)
        {
            Color cc = child.material.color; // Current Color
            child.material.color = new Color(cc.r, cc.g, cc.b, alpha);

            child.enabled = (alpha > 0);
        }
    }
    #endregion
    #region Coroutine

    IEnumerator Co_FadeOut()
    {
        isActive = false;

        yield return new WaitForSeconds(delayFadeout);
        while (currAlpha >= 0 && !isActive)
        {
            currAlpha -= Time.deltaTime * rate;
            SetAlpha(currAlpha);
            yield return null;
        }

        if (!isActive)
        {
            currAlpha = 0;
            SetAlpha(currAlpha);
        }
    }

    IEnumerator Co_FadeIn()
    {
        isActive = true;

        while (currAlpha <= 1 && isActive)
        {
            currAlpha += Time.deltaTime * rate;
            SetAlpha(currAlpha);
            yield return null;
        }

        if(isActive)
        { 
            currAlpha = 1;
            SetAlpha(currAlpha);
        }
    }
    #endregion
}
