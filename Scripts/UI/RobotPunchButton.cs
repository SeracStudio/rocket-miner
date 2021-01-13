using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPunchButton : MonoBehaviour
{
    public void PerformAction()
    {
        if (Application.isMobilePlatform)
            FindObjectOfType<Robot>().PunchActionPhone();
    }
}
