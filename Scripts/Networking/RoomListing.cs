﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListing : MonoBehaviourPunCallbacks
{

    public Text roomName;

    public RoomInfo RoomInfo { get; private set; }

    public void Awake()
    {}
    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        roomName.text = roomInfo.Name;
    }

}
