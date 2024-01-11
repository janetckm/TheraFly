using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Script_titleControl : MonoBehaviour
{
    public float fadeInTime = 0.5f;
    public float fadeOutTime = 0.5f;
    public float blinkInterval = 1.0f;
    public TMP_Text textObject;

    private Color targetColor;
    private float blinkTimer;
    private bool isFadingIn;

    void Start()
    {
        targetColor = new Color(textObject.color.r, textObject.color.g, textObject.color.b, 0.0f);
        blinkTimer = blinkInterval;
        isFadingIn = true;
    }

    void Update()
    {
        blinkTimer -= Time.deltaTime;
        if (blinkTimer <= 0.0f)
        {
            // reset timer
            blinkTimer = blinkInterval;
            // check fading animation
            if (isFadingIn)
            {
                StartCoroutine(FadeOut());
                isFadingIn = false;
            }
            else
            {
                StartCoroutine(FadeIn());
                isFadingIn = true;
            }
        }
    }

    IEnumerator FadeIn()
    {
        textObject.color = targetColor;
        for (float t = 0.0f; t < fadeInTime; t += Time.deltaTime)
        {
            float lerpValue = t / fadeInTime;
            textObject.color = Color.Lerp(targetColor, textObject.color, lerpValue);
            yield return null;
        }
        textObject.color = textObject.color;
    }

    IEnumerator FadeOut()
    {
        textObject.color = textObject.color;

        for (float t = 0.0f; t < fadeOutTime; t += Time.deltaTime)
        {
            float lerpValue = t / fadeOutTime;
            textObject.color = Color.Lerp(textObject.color, targetColor, lerpValue);
            yield return null;
        }

        textObject.color = targetColor;
    }
}