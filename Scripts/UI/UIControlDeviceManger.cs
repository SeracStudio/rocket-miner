using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControlDeviceManger : MonoBehaviour
{
    public GameObject PCControls, MobileControls;

    private void Awake()
    {
        if (Application.isMobilePlatform)
        {
            MobileControls.SetActive(true);
        }
        else
        {
            PCControls.SetActive(true);
        }
    }
}
