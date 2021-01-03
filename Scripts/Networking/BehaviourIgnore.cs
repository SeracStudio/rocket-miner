using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BehaviourIgnore : MonoBehaviour
{
    public MonoBehaviour[] behavioursToIgnore;

    private void Start()
    {
        if (GetComponent<PhotonView>().IsMine) return;

        foreach(var behaviour in behavioursToIgnore)
        {
            Destroy(behaviour);
        }
    }
}
