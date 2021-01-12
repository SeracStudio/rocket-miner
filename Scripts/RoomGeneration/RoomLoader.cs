using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomLoader : NetworkBehaviour
{
    public Direction direction;
    public Transform girlSpawn, robotSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if (!PhotonNetwork.IsMasterClient) return;
        if (!other.CompareTag("GIRL") && !other.CompareTag("ROBOT")) return;
        if (!MapController.RUNNING.currentRoom.cleared) return;

        TriggerRPC("LoadRoom", RpcTarget.AllBuffered);
    }

    [PunRPC]
    public void LoadRoom()
    {
        FindObjectOfType<Girl>().transform.position = girlSpawn.position;
        FindObjectOfType<Robot>().transform.position = robotSpawn.position;

        BlackScreenFader.INSTANCE.FadeTransition(0.25f);

        if (isOnMaster)
            MapController.RUNNING.LoadRoom(direction);
    }
}
