using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{

    public void LeavingRoom()
    {
        Debug.Log(PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LeaveRoom();
        Debug.Log("Room left");
    }

    public void JoinRoom(Text name)
    {
        PhotonNetwork.JoinRoom(name.text);
    }

}
