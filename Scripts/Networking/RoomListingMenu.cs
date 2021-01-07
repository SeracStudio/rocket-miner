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

    //private List<RoomListing> listings = new List<RoomListing>();
    private List<RoomInfo> fullRoomList = new List<RoomInfo>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        /*foreach (RoomInfo info in roomList)
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
                        else
                        {
                            Debug.Log("ha aparecido un random");
                        }


                    }
                }
                Debug.Log(roomList.Count);

                foreach (Transform child in content)
                {
                    Destroy(child.gameObject);
                }

                foreach (RoomInfo room in roomList)
                {
                    Debug.Log("yoagoaof "+room.Name);
                    if(room != null && !room.RemovedFromList)
                        Instantiate(roomListing, content).GetComponent<RoomListing>().SetRoomInfo(room);
                }
        */

        bool roomFound;
        foreach (RoomInfo room in roomList)
        {
            roomFound = false;
            foreach (RoomInfo fullRoom in fullRoomList)
            {
                if (room.Name == fullRoom.Name)
                    roomFound = true;
            }

            if (!roomFound)
                fullRoomList.Add(room);
            if (room.RemovedFromList || room.PlayerCount == 0)
            {
                fullRoomList.Remove(room);
            }
        }

        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach (RoomInfo room in fullRoomList)
        {
            Debug.Log("yoagoaof " + room.Name+ " , "+room.PlayerCount);
            if (room != null && room.PlayerCount > 0) { 

                Instantiate(roomListing, content).GetComponent<RoomListing>().SetRoomInfo(room);
            }
        }
    }

}
