using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRenderer : MonoBehaviour
{
    public Room room;
    public GameObject markerS, markerB, markerT;
    public int roomSize;

    private Dictionary<Vector3, MapRoom> map;
    private MapRoom loadedMapRoom;
    private Room loadedRoom;

    public void UpdateMap(Dictionary<Vector3, MapRoom> map)
    {
        this.map = map;
    }

    public void LoadRoom(Vector3 roomPos)
    {
        if (!map.ContainsKey(roomPos)) return;

        LoadRoom(map[roomPos]);
    }

    public void LoadRoom(MapRoom mapRoom)
    {
        if (loadedRoom != null) UnloadRoom();

        transform.position = Vector3.zero;
        loadedRoom = Instantiate(room, transform.position, Quaternion.identity);

        foreach (Direction opening in mapRoom.connections.Keys)
        {
            loadedRoom.RemoveWall(opening);
        }

        loadedMapRoom = mapRoom;
    }

    public void UnloadRoom()
    {
        Destroy(loadedRoom.gameObject);
    }

    public void LoadMap()
    {
        foreach(GameObject g in mapped)
        {
            Destroy(g.gameObject);
        }
        mapped.Clear();

        foreach (MapRoom mapRoom in map.Values)
        {
            transform.position = mapRoom.position * roomSize;
            Room loadedMapRoom = Instantiate(room, transform.position, Quaternion.identity);
            mapped.Add(loadedMapRoom.gameObject);

            foreach (Direction opening in mapRoom.connections.Keys)
            {
                loadedMapRoom.RemoveWall(opening);
            }

            if (mapRoom.type == RoomType.SPAWN) mapped.Add(Instantiate(markerS, transform.position, Quaternion.identity));
            if (mapRoom.type == RoomType.TREASURE) mapped.Add(Instantiate(markerT, transform.position, Quaternion.identity));
            if (mapRoom.type == RoomType.BOSS) mapped.Add(Instantiate(markerB, transform.position, Quaternion.identity));
        }
    }

    private List<GameObject> mapped = new List<GameObject>();
}
