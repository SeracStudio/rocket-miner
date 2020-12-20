using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    private ForwardPathGenerator forwardPath;

    public Room baseRoom;
    public float roomSize;
    private Dictionary<Vector3, Room> generatedRooms;

    public int maxLevelWidth, LevelsDepth;
    private int currentWidth, currentDepth;

    private Direction lastDirection;
    private Room lastRoom;

    private void Awake()
    {
        generatedRooms = new Dictionary<Vector3, Room>();

        forwardPath = new ForwardPathGenerator(Direction.SOUTH, 1, 3);
        currentWidth = currentDepth = 1;

        while (currentDepth < LevelsDepth)
        {
            SpawnRoom();
            MoveSpawnPoint();
        }

        SpawnRoom();
    }

    private void MoveSpawnPoint()
    {
        Direction direction = forwardPath.Generate();

        if(direction != forwardPath.forward)
        {
            currentWidth++;
            if (currentWidth > maxLevelWidth)
            {
                currentWidth = 1;
                direction = forwardPath.forward;
                forwardPath.Reset();
            }
        }   

        lastDirection = direction;
        if (direction == forwardPath.forward)
        {
            currentDepth++;
        }

        transform.Translate(DirectionFunc.GetVector(direction) * roomSize);
    }

    private void SpawnRoom()
    {
        Room nextRoom = Instantiate(baseRoom, transform.position, Quaternion.identity);
        nextRoom.Connect(lastDirection, lastRoom);
        lastRoom = nextRoom;
        generatedRooms.Add(transform.position, nextRoom);
    }
}
