using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject north, west, east, south;
    public Dictionary<Direction, Room> connections;

    private void Awake()
    {
        connections = new Dictionary<Direction, Room>();
    }

    public void Connect(Direction connection, Room room)
    {
        if (room == null) return;

        connections.Add(DirectionFunc.Inverse(connection), room);
        room.connections.Add(connection, this);

        RemoveWall(GetWallPosition(DirectionFunc.Inverse(connection)));
        room.RemoveWall(room.GetWallPosition(connection));
    }

    private GameObject GetWallPosition(Direction direction)
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

    private void RemoveWall(GameObject position)
    {
        foreach (Transform wallPos in position.transform)
        {
            Destroy(wallPos.gameObject);
        }
    }
}
