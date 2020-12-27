using System;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public static MapController RUNNING;

    public Action OnRoomLoaded;

    public int pathWidth, pathDepth, lateralRatio;
    [Range(0, 100)]
    public int branchingRatio;

    public MapRoom spawnRoom, treasureRoom, bossRoom;
    public MapRoom currentRoom, lastRoom;
    public Dictionary<Vector3, MapRoom> map;

    private MapGenerator mapGenerator;
    private MapRenderer mapRenderer;

    private void Awake()
    {
        RUNNING = this;

        mapGenerator = new MapGenerator(pathWidth, pathDepth, lateralRatio, branchingRatio);
        mapRenderer = GetComponent<MapRenderer>();

        //NewFloor();
        map = mapGenerator.NewMap();
        mapRenderer.Render(map);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            NewFloor();
            //map = mapGenerator.NewMap();
            //mapRenderer.Render(map);
        }
    }

    public void NewFloor()
    {
        map = mapGenerator.NewMap();
        foreach (MapRoom room in map.Values)
        {
            switch (room.type)
            {
                case RoomType.SPAWN:
                    spawnRoom = room;
                    break;
                case RoomType.BOSS:
                    treasureRoom = room;
                    break;
                case RoomType.TREASURE:
                    bossRoom = room;
                    break;
            }
        }
        LoadRoom(spawnRoom);
    }

    public void LoadRoom(MapRoom room)
    {
        player.transform.position = new Vector3(5, 0.5f, 0);
        lastRoom = currentRoom;
        mapRenderer.Render(room);
        currentRoom = room;
        OnRoomLoaded?.Invoke();
    }

    public GameObject player;

    public void LoadRoom(Direction direction)
    {
        lastRoom = currentRoom;
        MapRoom room = currentRoom.connections[direction];
        mapRenderer.Render(room);
        currentRoom = room;
        OnRoomLoaded?.Invoke();
    }
}
