using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLeaver : MonoBehaviourPunCallbacks
{
    public override void OnLeftRoom()
    {
        PhotonNetwork.LeaveRoom(true);
        Debug.Log("Room left");
    }


}
