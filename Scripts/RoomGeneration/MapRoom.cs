using System.Collections.Generic;
using UnityEngine;

public enum RoomType
{
    NORMAL,
    SPAWN,
    TREASURE,
    BOSS
}
public class MapRoom
{
    public RoomType type;
    public Vector3 position;
    public Dictionary<Direction, MapRoom> connections;

    public List<EnemySpawnStats> enemies;
    public BaseItem item;
    public bool cleared;

    public List<int> cornerWallsID;

    public MapRoom(Vector3 position)
    {
        this.type = RoomType.NORMAL;
        this.position = position;
        connections = new Dictionary<Direction, MapRoom>();
        enemies = new List<EnemySpawnStats>();

        cornerWallsID = new List<int>(4);
        for(int i = 0; i < 4; i++)
        {
            cornerWallsID.Add(Random.Range(0, 4));
        }
    }

    public void Connect(Direction direction, MapRoom room)
    {
        if (room == null) return;

        if (!connections.ContainsKey(DirectionFunc.Reverse(direction)))
            connections.Add(DirectionFunc.Reverse(direction), room);

        if (!room.connections.ContainsKey(direction))
            room.connections.Add(direction, this);
    }

    public void Disconnect(Direction direction)
    {
        if (!connections.ContainsKey(direction)) return;

        connections[direction].connections.Remove(DirectionFunc.Reverse(direction));
        connections.Remove(direction);
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
