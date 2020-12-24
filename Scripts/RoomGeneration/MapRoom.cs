using System.Collections.Generic;
using UnityEngine;

public class MapRoom
{
    public Vector3 position;
    public Dictionary<Direction, MapRoom> connections;

    public MapRoom(Vector3 position)
    {
        this.position = position;
        connections = new Dictionary<Direction, MapRoom>();
    }

    public void Connect(Direction connection, MapRoom room)
    {
        if (room == null) return;

        if (!connections.ContainsKey(DirectionFunc.Reverse(connection)))
            connections.Add(DirectionFunc.Reverse(connection), room);

        if (!room.connections.ContainsKey(connection))
            room.connections.Add(connection, this);
    }

    public bool IsConnected(Direction direction)
    {
        return connections.ContainsKey(direction);
    }

    public MapRoom GetConnection(Direction direction)
    {
        if (!IsConnected(direction)) return null;

        return connections[direction];
    }
}
