using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to " + PhotonNetwork.CloudRegion + " server.");
    }
}
