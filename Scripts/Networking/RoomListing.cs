using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour
{

    public Text roomName;
    
    public RoomInfo RoomInfo { get; private set; }
    public Image otherPlayer;
    public Image playerImage;

    public void Awake()
    {
        otherPlayer = FindInActiveObjectByName("Other_Player_Character_Image").GetComponent<Image>();
        playerImage = FindInActiveObjectByName("Character_Selected_image").GetComponent<Image>();
    }
    public void SetRoomInfo(RoomInfo roomInfo) {
        RoomInfo = roomInfo;
        roomName.text = roomInfo.Name;
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
        Debug.Log("Joined to the room.");
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

}
