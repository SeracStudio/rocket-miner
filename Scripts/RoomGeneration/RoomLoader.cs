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
        if (!other.CompareTag("GIRL") && !other.CompareTag("ROBOT")) return;

        PlayerInstantiater instantiater = FindObjectOfType<PlayerInstantiater>();

        instantiater.PlaceLocalPlayerAt(other.CompareTag("GIRL") ? girlSpawn.position : robotSpawn.position);
        instantiater.PlacePlayerAt(other.CompareTag("ROBOT") ? girlSpawn.position : robotSpawn.position);

        TriggerRPC("LoadRoomOnMaster", RpcTarget.MasterClient);
    }

    [PunRPC]
    public void LoadRoomOnMaster()
    {
        MapController.RUNNING.LoadRoom(direction);
    }
}
