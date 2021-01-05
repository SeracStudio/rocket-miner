using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour
{

    public Text roomName;

    public RoomInfo RoomInfo { get; set; }

    public void SetRoomInfo(RoomInfo roomInfo) {
        RoomInfo = roomInfo;
        roomName.text = roomInfo.Name;
    }

}
