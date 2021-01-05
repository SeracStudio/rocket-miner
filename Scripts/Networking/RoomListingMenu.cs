using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomListingMenu : MonoBehaviourPunCallbacks
{
    //[SerializeField]
    public RoomListing roomListing;
    public Transform content;

    private List<RoomListing> roomListings = new List<RoomListing>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        //En el OnConnectedToMaster hay que poner PhotonManager.JoinLobby para que salgan las salas
        foreach (RoomInfo info in roomList)
        {
            //Removes from rooms list
            if (info.RemovedFromList) {

                int index = roomListings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index != -1) { 
                    Destroy(roomListings[index].gameObject);
                    roomListings.RemoveAt(index);
                    Debug.Log("Room removed from the list.");
                }
            }

            //Adds from rooms list
            else
            {
                RoomListing listing = Instantiate(roomListing, content);
                if (listing != null)
                {
                    listing.SetRoomInfo(info);
                    roomListings.Add(listing);
                    Debug.Log("Room added to the list.");
                }
            }

        }
    }


   
}
