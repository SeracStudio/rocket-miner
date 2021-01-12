using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkIgnore : NetworkBehaviour
{
    public MonoBehaviour[] behavioursToIgnore;

    protected override void Awake()
    {
        base.Awake();
        if (isOnMaster) return;

        foreach(var behaviour in behavioursToIgnore)
        {
            Destroy(behaviour);
        }

        Destroy(this);
    }
}
