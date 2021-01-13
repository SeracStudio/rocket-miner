using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotShieldButton : MonoBehaviour
{
    public void PerformAction()
    {
        if (Application.isMobilePlatform)
            FindObjectOfType<Robot>().OnShieldActionPhone();
    }

    public void PerformOtherAction()
    {
        if (Application.isMobilePlatform)
            FindObjectOfType<Robot>().OffShieldActionPhone();
    }
}
