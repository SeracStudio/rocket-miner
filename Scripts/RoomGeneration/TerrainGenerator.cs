using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public Room baseRoom, branchRoom;
    public float roomSize;

    public int pathWidth, pathDepth, lateralRatio;
    [Range(0, 100)]
    public int branchingRatio;
    private int currentWidth, currentDepth;

    private ForwardPathGenerator path;
    private Dictionary<Vector3, Room> generatedRooms;
    private Direction lastDirection;
    private Room lastRoom;

    private void Awake()
    {
        generatedRooms = new Dictionary<Vector3, Room>();

        GeneratePath(DirectionFunc.GetRandom(), baseRoom, null);

        Room[] criticalRooms = new Room[generatedRooms.Count];
        generatedRooms.Values.CopyTo(criticalRooms, 0);

        foreach(Room criticalRoom in criticalRooms)
        {
            if (Random.Range(0, 100) >= branchingRatio) continue;

            transform.position = criticalRoom.transform.position;
            List<Direction> unconnected = DirectionFunc.GetAll(criticalRoom.connections.Keys.ToList());
            GeneratePath(DirectionFunc.GetRandom(unconnected), branchRoom, criticalRoom);
        }
    }

    private void GeneratePath(Direction forward, Room roomType, Room starting)
    {
        path = new ForwardPathGenerator(forward, 1, lateralRatio);
        currentWidth = currentDepth = 1;
        lastRoom = starting;

        if (lastRoom == null)
            SpawnRoom(roomType);

        while (currentDepth < pathDepth)
        {
            MoveSpawnPoint();
            SpawnRoom(roomType);
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

        transform.Translate(DirectionFunc.GetVector(direction) * roomSize);
    }

    private void SpawnRoom(Room room)
    {
        Room nextRoom;

        if (generatedRooms.ContainsKey(transform.position))
        {
            nextRoom = generatedRooms[transform.position];
        }
        else
        {
            nextRoom = Instantiate(room, transform.position, Quaternion.identity);
            generatedRooms.Add(transform.position, nextRoom);
        }

        nextRoom.Connect(lastDirection, lastRoom);
        lastRoom = nextRoom;
    }

    private void ClearTerrain()
    {
        foreach (Room room in generatedRooms.Values)
            Destroy(room.gameObject);

        transform.position = Vector3.zero;
        generatedRooms.Clear();
    }
}
