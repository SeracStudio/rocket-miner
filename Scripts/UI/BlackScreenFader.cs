using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreenFader : MonoBehaviour
{
    public static BlackScreenFader INSTANCE;
    public Image blackScreen;

    private void Awake()
    {
        INSTANCE = this;
    }

    [PunRPC]
    public void FadeTransition(float duration)
    {
        StartCoroutine(nameof(ReversedBlackFade), duration);
    }

    IEnumerator ReversedBlackFade(float duration)
    {
        Color screenColor = blackScreen.color;
        float currentTime = 0f;
        float alphaValue;

        blackScreen.color = new Color(screenColor.r, screenColor.g, screenColor.b, 1);

        while (currentTime < duration)
        {
            alphaValue = currentTime / duration;

            screenColor = new Color(screenColor.r, screenColor.g, screenColor.b, Mathf.Lerp(1, 0, alphaValue));
            blackScreen.color = screenColor;

            currentTime += Time.deltaTime;

            yield return null;
        }

        blackScreen.color = new Color(screenColor.r, screenColor.g, screenColor.b, 0);
    }

    IEnumerator FadeTransitionCoroutine(float duration)
    {
        Color screenColor = blackScreen.color;
        float currentTime = 0f;
        float middleKeyFrameTime = duration / 2f;
        float alphaValue;

        while (currentTime < middleKeyFrameTime)
        {
            alphaValue = currentTime / middleKeyFrameTime;

            screenColor = new Color(screenColor.r, screenColor.g, screenColor.b, Mathf.Lerp(0, 1, alphaValue));
            blackScreen.color = screenColor;

            currentTime += Time.deltaTime;

            yield return null;
        }

        currentTime = 0f;

        while (currentTime < middleKeyFrameTime)
        {
            alphaValue = currentTime / middleKeyFrameTime;

            screenColor = new Color(screenColor.r, screenColor.g, screenColor.b, Mathf.Lerp(1, 0, alphaValue));
            blackScreen.color = screenColor;

            currentTime += Time.deltaTime;

            yield return null;
        }

        blackScreen.color = new Color(screenColor.r, screenColor.g, screenColor.b, 0);
    }
}
