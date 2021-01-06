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

    private List<RoomListing> listings = new List<RoomListing>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

        foreach (RoomInfo info in roomList)
        {
            //Removes from rooms list
            if (info.RemovedFromList) {
                int index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index != -1) { 
                    Destroy(listings[index].gameObject);
                    listings.RemoveAt(index);
                    Debug.Log("Room removed from the list.");
                }
            }
            
            //Adds from rooms list
            else
            {
                int index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                RoomListing listing = Instantiate(roomListing, content);
                if (index == -1)
                {
                    if (listing != null)
                    {
                        listing.SetRoomInfo(info);
                        listings.Add(listing);
                        Debug.Log("Room added to the list.");

                    }
                }
                
                
            }
        }
    }

    public override void OnJoinedRoom()
    {
        listings.Clear();
    }

}
