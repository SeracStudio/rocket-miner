using Photon.Pun;
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
    public int currentFloor;
    public Dictionary<Vector3, MapRoom> currentMap;
    private Dictionary<Vector3, MapRoom>[] fullMap;
    private int enemiesLeft;

    private MapGenerator mapGenerator;
    private MapEnemyFiller mapEnemyFiller;
    private MapItemFiller mapItemFiller;
    private MapRenderer mapRenderer;

    private void Awake()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Destroy(this);
            return;
        }

        RUNNING = this;
        fullMap = new Dictionary<Vector3, MapRoom>[5];

        mapGenerator = new MapGenerator(pathWidth, pathDepth, lateralRatio, branchingRatio);
        mapEnemyFiller = GetComponent<MapEnemyFiller>();
        mapItemFiller = GetComponent<MapItemFiller>();
        mapRenderer = GetComponent<MapRenderer>();

        for (int i = 0; i < 5; i++)
        {
            fullMap[i] = mapGenerator.NewMap();
            mapEnemyFiller.FillMapWithEnemies(fullMap[i], i);
            mapItemFiller.FillMapWithItems(fullMap[i]);
        }

        LoadMap(fullMap[currentFloor]);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            currentFloor++;
            LoadMap(fullMap[currentFloor]);
        }
    }

    public void LoadMap(Dictionary<Vector3, MapRoom> map)
    {
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
        lastRoom = currentRoom;
        //room.cleared = true;
        mapRenderer.Render(room);
        room.cleared = true;
        currentRoom = room;
        enemiesLeft = room.enemies.Count;
        foreach (EnemySpawnStats enemy in mapRenderer.loadedRoom.spawnedEnemies)
        {
            if (enemy.isSlime) enemiesLeft += 6;
            enemy.GetComponent<EnemySpawnStats>().OnDeath += EnemyEliminated;
        }
        OnRoomLoaded?.Invoke();
    }

    public void LoadRoom(Direction direction)
    {
        LoadRoom(currentRoom.connections[direction]);
    }

    public void EnemyEliminated()
    {
        enemiesLeft--;
        if (enemiesLeft == 0)
        {
            foreach (Direction opening in currentRoom.connections.Keys)
            {
                //mapRenderer.loadedRoom.OpenDoor(opening);
                mapRenderer.loadedRoom.GetComponent<PhotonView>().RPC("OpenDoor", RpcTarget.AllBuffered, opening);
            }
        }
    }
}
