using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapGenerator
{
    private int pathWidth, pathDepth, lateralRatio, branchingRatio;
    private int currentWidth, currentDepth;

    private ForwardPathGenerator path;
    private Vector3 currentPos;
    private Dictionary<Vector3, MapRoom> generatedRooms;
    private Direction lastDirection;
    private MapRoom lastRoom;

    public MapGenerator(int pathWidth, int pathDepth, int lateralRatio, int branchingRatio)
    {
        UpdateConfiguration(pathWidth, pathDepth, lateralRatio, branchingRatio);
        generatedRooms = new Dictionary<Vector3, MapRoom>();
    }

    private void GeneratePath(Direction forward, MapRoom starting)
    {
        path = new ForwardPathGenerator(forward, 1, lateralRatio);
        currentWidth = currentDepth = 1;
        lastRoom = starting;

        if (lastRoom == null)
            SpawnRoom();

        while (currentDepth < pathDepth)
        {
            MoveSpawnPoint();
            SpawnRoom();
        }
    }

    private void MoveSpawnPoint()
    {
        Direction direction = path.Generate();

        if (direction != path.forward)
        {
            currentWidth++;
            if (currentWidth > pathWidth)
            {
                currentWidth = 1;
                direction = path.forward;
                path.Reset();
            }
        }

        lastDirection = direction;
        if (direction == path.forward)
        {
            currentDepth++;
        }

        currentPos += DirectionFunc.GetVector(direction);
    }

    private void SpawnRoom()
    {
        MapRoom nextRoom;

        if (generatedRooms.ContainsKey(currentPos))
        {
            nextRoom = generatedRooms[currentPos];
        }
        else
        {
            nextRoom = new MapRoom(currentPos);
            generatedRooms.Add(currentPos, nextRoom);
        }

        nextRoom.Connect(lastDirection, lastRoom);
        lastRoom = nextRoom;
    }

    private void AddSpecialRoom(RoomType roomType)
    {
        List<MapRoom> rooms = generatedRooms.Values.ToList();
        Direction direction = Direction.NORTH;
        MapRoom sourceRoom = lastRoom;
        bool validRoom = false;
        while (!validRoom)
        {
            sourceRoom = rooms[Random.Range(0, rooms.Count)];
            if (sourceRoom.type != RoomType.NORMAL) continue;
            foreach(Direction sourceDir in DirectionFunc.GetAll(sourceRoom.connections.Keys.ToList()))
            {
                if (!generatedRooms.ContainsKey(sourceRoom.position + DirectionFunc.GetVector(sourceDir)))
                {
                    direction = sourceDir;
                    validRoom = true;
                    
                    break;
                }
            }
        }

        currentPos = sourceRoom.position + DirectionFunc.GetVector(direction);
        //Debug.Log(direction + ", " + sourceRoom.position + ", " + currentPos + ", " + sourceRoom.connections.Values.Count);
        lastRoom = sourceRoom;
        lastDirection = direction;
        SpawnRoom();
        lastRoom.type = roomType;
    }

    public void UpdateConfiguration(int pathWidth, int pathDepth, int lateralRatio, int branchingRatio)
    {
        this.pathWidth = pathWidth;
        this.pathDepth = pathDepth;
        this.lateralRatio = lateralRatio;
        this.branchingRatio = branchingRatio;
    }

    public Dictionary<Vector3, MapRoom> NewMap()
    {
        generatedRooms.Clear();
        currentPos = Vector3.zero;

        GeneratePath(DirectionFunc.GetRandom(), null);

        Vector3[] criticalPositions = new Vector3[generatedRooms.Count];
        generatedRooms.Keys.CopyTo(criticalPositions, 0);

        foreach (Vector3 criticalPos in criticalPositions)
        {
            if (Random.Range(0, 100) >= this.branchingRatio) continue;

            MapRoom criticalRoom = generatedRooms[criticalPos];
            currentPos = criticalPos;
            List<Direction> unconnected = DirectionFunc.GetAll(criticalRoom.connections.Keys.ToList());
            GeneratePath(DirectionFunc.GetRandom(unconnected), criticalRoom);
        }

        AddSpecialRoom(RoomType.SPAWN);
        AddSpecialRoom(RoomType.BOSS);
        AddSpecialRoom(RoomType.TREASURE);

        return generatedRooms;
    }
}
