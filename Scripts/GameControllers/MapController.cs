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
    public Dictionary<Vector3, MapRoom> map;

    private MapGenerator mapGenerator;
    private MapRenderer mapRenderer;

    private void Awake()
    {
        RUNNING = this;

        mapGenerator = new MapGenerator(pathWidth, pathDepth, lateralRatio, branchingRatio);
        mapRenderer = GetComponent<MapRenderer>();

        NewFloor();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            NewFloor();
        }
    }

    private void NewFloor()
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

    private void LoadRoom(MapRoom room)
    {
        mapRenderer.RenderRoom(spawnRoom);
        OnRoomLoaded?.Invoke();
    }
}