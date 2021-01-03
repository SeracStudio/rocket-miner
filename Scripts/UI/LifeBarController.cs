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
    // Start is called before the first frame update
    void Start()
    {
        damage = 0.1f;
        lifeBefore = lifebar.fillAmount;
        beaten = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            lifeBefore = lifebar.fillAmount;
            beaten = true;
        }

        if (beaten) { 
                lifebar.fillAmount -= damage * Time.deltaTime;
                if((lifeBefore-damage) >= lifebar.fillAmount)
                {
                    beaten = false;
                    lifeBefore = lifebar.fillAmount;
                }
        }
       

    }
}
