using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreenFader : MonoBehaviour
{
    public static BlackScreenFader INSTANCE;
    public Image blackScreen;

    public Image gameOverScreen, victoryScreen;

    private void Awake()
    {
        INSTANCE = this;
    }

    [PunRPC]
    public void FadeTransition(float duration)
    {
        StartCoroutine(nameof(ReversedBlackFade), duration);
    }

    [PunRPC]
    public void ReverseFadeTransition(float duration)
    {
        StartCoroutine(nameof(BlackFade), duration);
    }

    IEnumerator BlackFade(float duration)
    {
        Color screenColor = blackScreen.color;
        float currentTime = 0f;
        float alphaValue;

        blackScreen.color = new Color(screenColor.r, screenColor.g, screenColor.b, 0);

        if (gameOverScreen.enabled)
            gameOverScreen.color = new Color(gameOverScreen.color.r, gameOverScreen.color.g, gameOverScreen.color.b, 0);

        if (victoryScreen.enabled)
            victoryScreen.color = new Color(victoryScreen.color.r, victoryScreen.color.g, victoryScreen.color.b, 0);

        while (currentTime < duration)
        {
            alphaValue = currentTime / duration;

            screenColor = new Color(screenColor.r, screenColor.g, screenColor.b, Mathf.Lerp(0, 1, alphaValue));
            blackScreen.color = screenColor;

            if (gameOverScreen.enabled)
                gameOverScreen.color = new Color(gameOverScreen.color.r, gameOverScreen.color.g, gameOverScreen.color.b, Mathf.Lerp(0, 1, alphaValue));

            if (victoryScreen.enabled)
                victoryScreen.color = new Color(victoryScreen.color.r, victoryScreen.color.g, victoryScreen.color.b, Mathf.Lerp(0, 1, alphaValue));

            currentTime += Time.deltaTime;

            yield return null;
        }

        blackScreen.color = new Color(screenColor.r, screenColor.g, screenColor.b, 1);

        if (gameOverScreen.enabled)
            gameOverScreen.color = new Color(gameOverScreen.color.r, gameOverScreen.color.g, gameOverScreen.color.b, 1);

        if (victoryScreen.enabled)
            victoryScreen.color = new Color(victoryScreen.color.r, victoryScreen.color.g, victoryScreen.color.b, 1);
    }

    IEnumerator ReversedBlackFade(float duration)
    {
        Color screenColor = blackScreen.color;
        float currentTime = 0f;
        float alphaValue;

        blackScreen.color = new Color(screenColor.r, screenColor.g, screenColor.b, 1);

        if (gameOverScreen.enabled)
            gameOverScreen.color = new Color(gameOverScreen.color.r, gameOverScreen.color.g, gameOverScreen.color.b, 1);

        if (victoryScreen.enabled)
            victoryScreen.color = new Color(victoryScreen.color.r, victoryScreen.color.g, victoryScreen.color.b, 1);

        while (currentTime < duration)
        {
            alphaValue = currentTime / duration;

            screenColor = new Color(screenColor.r, screenColor.g, screenColor.b, Mathf.Lerp(1, 0, alphaValue));
            blackScreen.color = screenColor;

            if (gameOverScreen.enabled)
                gameOverScreen.color = new Color(gameOverScreen.color.r, gameOverScreen.color.g, gameOverScreen.color.b, Mathf.Lerp(1, 0, alphaValue));


            if (victoryScreen.enabled)
                victoryScreen.color = new Color(victoryScreen.color.r, victoryScreen.color.g, victoryScreen.color.b, Mathf.Lerp(1, 0, alphaValue));

            currentTime += Time.deltaTime;

            yield return null;
        }

        blackScreen.color = new Color(screenColor.r, screenColor.g, screenColor.b, 0);

        if (gameOverScreen.enabled)
            gameOverScreen.color = new Color(gameOverScreen.color.r, gameOverScreen.color.g, gameOverScreen.color.b, 0);

        if (victoryScreen.enabled)
            victoryScreen.color = new Color(victoryScreen.color.r, victoryScreen.color.g, victoryScreen.color.b, 0);
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
