using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementsManager : MonoBehaviour
{
    public Image cooldown;
    public KeyCode key;
    public float time = 1.0f;
    private bool usedMov;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) && usedMov == false)
        {
            cooldown.fillAmount = 0;
            usedMov = true;
        }

        if (usedMov)
        {
            cooldown.fillAmount += (1 / time) * Time.deltaTime;
            if (cooldown.fillAmount == 1)
            {
                usedMov = false;
            }
        }
    }
}
