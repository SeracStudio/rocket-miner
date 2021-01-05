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

    //[SerializeField]
    public Text roomName;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        
    }

    public void CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            Debug.Log("Photon is disconnected");
            return;
        }


        if(roomName.text == "" || ConsistsOfWhiteSpace(roomName.text))
        {
            PhotonNetwork.CreateRoom("Defecto", new Photon.Realtime.RoomOptions() { MaxPlayers = neededPlayers });
        }
        else
        {
            PhotonNetwork.CreateRoom(roomName.text, new Photon.Realtime.RoomOptions() { MaxPlayers = neededPlayers });
        }
        //Debug.Log(PhotonNetwork.InRoom);
    }
    public bool ConsistsOfWhiteSpace(string s)
    {
        foreach (char c in s)
        {
            if (c != ' ') return false;
        }
        return true;

    }
    public override void OnCreatedRoom()
    {
        Debug.Log("Room created.");
    }



    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
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