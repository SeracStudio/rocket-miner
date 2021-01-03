using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomJoiner : MonoBehaviourPunCallbacks
{
    public string gameSceneName;
    public byte neededPlayers;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions() { MaxPlayers = neededPlayers });
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room created.");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Room joined.");     
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Error joining room.");
        CreateRoom();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == neededPlayers && PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.LoadLevel(gameSceneName);
            }
        }
    }
}
