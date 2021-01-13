using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlDashButton : MonoBehaviour
{
    public void PerformAction()
    {
        if (Application.isMobilePlatform)

            FindObjectOfType<Girl>().DashActionPhone();
    }
}
