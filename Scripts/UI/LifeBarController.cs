using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarController : MonoBehaviour
{
    public Image lifebar;
    private float damage;
    private float lifeBefore;
    private bool beaten;
    private float targetLife;
    // Start is called before the first frame update
    void Start()
    {
        lifeBefore = lifebar.fillAmount;
        targetLife = lifeBefore;
        beaten = false;
        //FindObjectOfType<Girl>().GetComponent<StatsController>().OnStatChanged += UpdateLifeBar;
    }

    void Update()
    {
        if (beaten)
        {
            /*
            lifebar.fillAmount -= damage * Time.deltaTime;
            if ((lifeBefore - damage) >= lifebar.fillAmount)
            {
                beaten = false;
                lifeBefore = lifebar.fillAmount;
            }
            */
        }   
    }

    public void UpdateLifeBar(Stat stat, float amount)
    {
        GetComponent<PhotonView>().RPC("UpdateLifeBarRPC", RpcTarget.AllBuffered, stat, amount);
    }

    [PunRPC]
    public void UpdateLifeBarRPC(Stat stat, float amount)
    {
        if (stat != Stat.HEALTH) return;

        damage = lifeBefore - Mathf.Abs(amount / 100f);
        targetLife -= damage;

        lifebar.color = ComputeColorBasedOnSpeed(lifebar.fillAmount * 100);

        lifebar.fillAmount = targetLife;
        lifeBefore = lifebar.fillAmount;
        beaten = true;
    }

    private Color ComputeColorBasedOnSpeed(float life)
    {
        Gradient speedGradient = new Gradient();
        GradientColorKey[] colorKey;
        GradientAlphaKey[] alphaKey;

        Color bottomColor = new Color(0.8f, 0f, 0.1f);
        Color topColor = new Color(0.8f, 0.874f, 0.424f);


        colorKey = new GradientColorKey[2];
        colorKey[0].color = bottomColor;
        colorKey[0].time = 0.0f;
        colorKey[1].color = topColor;
        colorKey[1].time = 1.0f;
        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 1.0f;

        speedGradient.SetKeys(colorKey, alphaKey);

        return speedGradient.Evaluate(life / 70f);
    }
}
