using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    private DirectionGenerator directionGenerator;

    public Room baseRoom;
    public float roomSize;
    private Dictionary<Vector3, Room> generatedRooms;

    public int maxLevelWidth, LevelsDepth;
    private int currentWidth, currentDepth;

    private Direction lastDirection;
    private Room lastRoom;
    //MODIFICATION
    public int mod;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            lastRoom = null;
            transform.position = Vector3.zero;
            foreach(var v in generatedRooms.Values)
            {
                Destroy(v.gameObject);
            }

            generatedRooms.Clear();

            directionGenerator = new DirectionGenerator(new Dictionary<Direction, int>()
        {
            { Direction.NORTH, 0},
            { Direction.WEST, 2},
            { Direction.EAST, 2},
            { Direction.SOUTH, 1},
        });
            currentWidth = currentDepth = 1;

            while (currentDepth < LevelsDepth)
            {
                SpawnRoom();
                MoveSpawnPoint();
            }

            SpawnRoom();
        }
    }

    private void Awake()
    {
        generatedRooms = new Dictionary<Vector3, Room>();

        directionGenerator = new DirectionGenerator(new Dictionary<Direction, int>()
        {
            { Direction.NORTH, 0},
            { Direction.WEST, 2},
            { Direction.EAST, 2},
            { Direction.SOUTH, 1},
        });
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
        Direction direction = directionGenerator.Generate();

        if (direction == Direction.WEST)
        {
            currentWidth++;
            directionGenerator.ReplaceDirectionSet(new Dictionary<Direction, int> {
                { Direction.WEST, 2 },
                { Direction.SOUTH, 1 }
            });
        }

        if (direction == Direction.EAST)
        {
            currentWidth++;
            directionGenerator.ReplaceDirectionSet(new Dictionary<Direction, int> {
                { Direction.EAST, 2 },
                { Direction.SOUTH, 1 }
            });
        }

        if (currentWidth > maxLevelWidth)
        {
            currentWidth = 1;
            direction = Direction.SOUTH;
        }

        if (direction == Direction.SOUTH)
        {
            directionGenerator.ReplaceDirectionSet(new Dictionary<Direction, int> {
                { Direction.WEST, 2 },
                { Direction.EAST, 2 },
                { Direction.SOUTH, 1 }
            });
            currentDepth++;
        }

        lastDirection = direction;

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
