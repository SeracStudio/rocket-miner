using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public SpawnObject north, west, east, south;
    public List<EnemySpawnStats> spawnedEnemies;
    private void Awake()
    {
        spawnedEnemies = new List<EnemySpawnStats>();
        spawnedEnemies.Clear();
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

    public void CloseDoor(Direction direction)
    {
        GetWallPosition(direction).Show();
    }

    public void OpenDoor(Direction direction)
    {
        GetWallPosition(direction).Hide();
    }
}
