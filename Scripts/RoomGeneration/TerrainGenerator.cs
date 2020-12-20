using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    private ForwardPathGenerator path;

    public Room baseRoom, branchRoom;
    public float roomSize;
    private Dictionary<Vector3, Room> generatedRooms;

    public int maxLevelWidth, LevelsDepth;
    private int currentWidth, currentDepth;

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
            transform.position = criticalRoom.transform.position;
            GeneratePath(DirectionFunc.GetRandom(), branchRoom, criticalRoom);
        }
    }

    private void GeneratePath(Direction forward, Room roomType, Room starting)
    {
        path = new ForwardPathGenerator(forward, 1, 3);
        currentWidth = currentDepth = 1;
        lastRoom = starting;

        if (lastRoom == null)
            SpawnRoom(roomType);

        while (currentDepth < LevelsDepth)
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
            if (currentWidth > maxLevelWidth)
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
}
