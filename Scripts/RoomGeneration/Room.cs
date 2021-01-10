using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Room : MonoBehaviour
{
    public SpawnObject northWest, northEast, southWest, southEast;
    public SpawnObject north, west, east, south;
    public List<EnemySpawnStats> spawnedEnemies;

    private void Awake()
    {
        spawnedEnemies = new List<EnemySpawnStats>();
        spawnedEnemies.Clear();
    }

    [PunRPC]
    public void SpawnCornerWalls(List<int> cornerWallsID)
    {
        northWest.TriggerRPC("SetAndSpawn", RpcTarget.AllBuffered, cornerWallsID[0]);
        northEast.TriggerRPC("SetAndSpawn", RpcTarget.AllBuffered, cornerWallsID[1]);
        southWest.TriggerRPC("SetAndSpawn", RpcTarget.AllBuffered, cornerWallsID[2]);
        southEast.TriggerRPC("SetAndSpawn", RpcTarget.AllBuffered, cornerWallsID[3]);
    }

    private SpawnObject GetWallPosition(Direction direction)
    {
        switch (direction)
        {
            case Direction.NORTH:
                return north;
            case Direction.WEST:
                return west;
            case Direction.EAST:
                return east;
            case Direction.SOUTH:
            default:
                return south;
        }
    }

    public void RemoveWall(Direction direction)
    {
        GetWallPosition(direction).Destroy();
    }

    [PunRPC]
    public void CloseDoor(Direction direction)
    {
        GetWallPosition(direction).Show();
    }

    [PunRPC]
    public void OpenDoor(Direction direction)
    {
        GetWallPosition(direction).Hide();
    }
}
