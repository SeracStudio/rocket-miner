using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIManager : NetworkBehaviour
{
    public static InGameUIManager RUNNING;
    public ItemPopUp popUp;

    protected override void Awake()
    {
        base.Awake();
        RUNNING = this;
    }

    [PunRPC]
    public void LaunchPopUp(string name, string desc)
    {
        Instantiate(popUp, transform).SetAndLaunch(name, desc);
    }
}
