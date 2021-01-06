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

    public override void OnMasterClientSwitched(Photon.Realtime.Player newMasterClient)
    {
        //PhotonNetwork.SetMasterClient(PhotonNetwork.CurrentRoom.GetPlayer(0));
        Debug.Log("El master es "+ PhotonNetwork.MasterClient);
    }

}
