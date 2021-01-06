using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkController : MonoBehaviourPunCallbacks
{
    private bool isMaster = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("connecting to server");
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Update()
    {
        
        /*
        if(PhotonNetwork.MasterClient == null)
        {
            if(isMaster)
                PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);
        }
        else
        {
            isMaster = true;
        }
        */
        //Debug.Log(isMaster);
    }


    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to " + PhotonNetwork.CloudRegion + " server.");
        if (!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from server for " + cause.ToString());
    }


}