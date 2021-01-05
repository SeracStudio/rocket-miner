using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkIgnore : NetworkBehaviour
{
    public MonoBehaviour[] behavioursToIgnore;

    private void Start()
    {
        if (isOnMaster) return;

        foreach (var behaviour in behavioursToIgnore)
        {
            Destroy(behaviour);
        }

        Destroy(this);
    }
}