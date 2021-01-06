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
        //Debug.Log("Room Created.");
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

    public override void OnJoinedRoom()
    {
        if (!PhotonNetwork.IsMasterClient){
            //base.photonView.RPC("loadImages", RpcTarget.All);
        }
        Debug.Log("Room joined.");
    }

    [PunRPC]
    public void loadImages()
    {
        Image otherPlayer = FindInActiveObjectByName("Other_Player_Character_Image").GetComponent<Image>();
        otherPlayer.color = new Color(otherPlayer.color.r, otherPlayer.color.g, otherPlayer.color.b, 1.0f);
    }

    private GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Error joining room.");
        CreateRoom();
    }



    public void StartNewGame()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == neededPlayers && PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(gameSceneName);
            Debug.Log("La partida empieza");
        }
        else
        {
            Debug.Log("Faltan jugadores");
        }
    }

    private void Update()
    {

    }
}