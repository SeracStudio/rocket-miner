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
    private Dictionary<string, RoomInfo> fullRoomList = new Dictionary<string, RoomInfo>();

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
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach (RoomInfo info in roomList)
        {
            // Remove room from cached room list if it got closed, became invisible or was marked as removed
            if (!info.IsOpen || !info.IsVisible || info.RemovedFromList)
            {
                if (fullRoomList.ContainsKey(info.Name))
                {
                    fullRoomList.Remove(info.Name);
                }

                continue;
            }

            // Update cached room info
            if (fullRoomList.ContainsKey(info.Name))
            {
                fullRoomList[info.Name] = info;
            }
            // Add new room info to cache
            else
            {
                fullRoomList.Add(info.Name, info);
            }
        }

        foreach (RoomInfo room in fullRoomList.Values)
        {
            Debug.Log("yoagoaof " + room.Name+ " , "+room.PlayerCount);
            
            Instantiate(roomListing, content).GetComponent<RoomListing>().SetRoomInfo(room);
           
        }
    }

    public override void OnJoinedRoom()
    {
        fullRoomList.Clear();
    }


}
