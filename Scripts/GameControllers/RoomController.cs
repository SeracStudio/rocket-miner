using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public Room room;
    public int pathWidth, pathDepth, lateralRatio;
    [Range(0, 100)]
    public int branchingRatio;

    private RoomController RUNNING;
    private MapGenerator mapGenerator;
    private Dictionary<Vector3, MapRoom> map;
    private MapRoom loadedMapRoom;
    private Room loadedRoom;

    private void Awake()
    {
        RUNNING = this;

        mapGenerator = new MapGenerator(pathWidth, pathDepth, lateralRatio, branchingRatio);
        map = mapGenerator.NewMap();
        LoadRoom(map[Vector3.zero]);
    }

    public void LoadRoom(MapRoom mapRoom)
    {
        if (loadedRoom != null) UnloadRoom();

        transform.position = Vector3.zero;
        loadedRoom = Instantiate(room, transform.position, Quaternion.identity);

        foreach(Direction opening in mapRoom.connections.Keys)
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
        foreach(MapRoom mapRoom in map.Values)
        {
            transform.position = mapRoom.position * 20;
            loadedRoom = Instantiate(room, transform.position, Quaternion.identity);

            foreach (Direction opening in mapRoom.connections.Keys)
            {
                loadedRoom.RemoveWall(opening);
            }
        }
    }
}
