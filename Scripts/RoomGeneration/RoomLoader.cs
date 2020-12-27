using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLoader : MonoBehaviour
{
    public Direction direction;
    public Transform crossSpawn;

    private void OnTriggerEnter(Collider other)
    {
        MapController.RUNNING.player.transform.position = crossSpawn.position;
        MapController.RUNNING.LoadRoom(direction);
    }
}
