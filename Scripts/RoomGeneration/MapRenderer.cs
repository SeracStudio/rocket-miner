using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRenderer : MonoBehaviour
{
    public Room room;
    public Room loadedRoom;
    public GameObject markerS, markerB, markerT;
    public int roomSize;

    private readonly List<GameObject> rendered = new List<GameObject>();

    public void Render(MapRoom mapRoom)
    {
        ClearRender();

        transform.position = Vector3.zero;
        loadedRoom = Instantiate(room, transform.position, Quaternion.identity);
        rendered.Add(loadedRoom.gameObject);

        foreach (Direction opening in mapRoom.connections.Keys)
        {
            if (mapRoom.type == RoomType.NORMAL && !mapRoom.cleared)
            {
                loadedRoom.CloseDoor(opening);
            }
            else
            {
                loadedRoom.OpenDoor(opening);
            }
        }

        if (mapRoom.type == RoomType.SPAWN) rendered.Add(Instantiate(markerS, transform.position, Quaternion.identity));
        if (mapRoom.type == RoomType.TREASURE) rendered.Add(Instantiate(markerT, transform.position, Quaternion.identity));
        if (mapRoom.type == RoomType.BOSS) rendered.Add(Instantiate(markerB, transform.position, Quaternion.identity));

        if (!mapRoom.cleared)
        {
            foreach (EnemySpawnStats enemy in mapRoom.enemies)
            {
                
                float randomX = Random.Range(-7, 7);
                float randomY = Random.Range(-7, 7);

                EnemySpawnStats enemySpawned = Instantiate(enemy, new Vector3(randomX, 0, randomY), Quaternion.identity);
                loadedRoom.spawnedEnemies.Add(enemySpawned);
                rendered.Add(enemySpawned.gameObject);
            }
        }
    }

    public void Render(Dictionary<Vector3, MapRoom> map)
    {
        ClearRender();

        foreach (MapRoom mapRoom in map.Values)
        {
            transform.position = mapRoom.position * roomSize;
            Room loadedMapRoom = Instantiate(room, transform.position, Quaternion.identity);
            rendered.Add(loadedMapRoom.gameObject);

            foreach (Direction opening in mapRoom.connections.Keys)
            {
                loadedMapRoom.RemoveWall(opening);
            }

            if (mapRoom.type == RoomType.SPAWN) rendered.Add(Instantiate(markerS, transform.position, Quaternion.identity));
            if (mapRoom.type == RoomType.TREASURE) rendered.Add(Instantiate(markerT, transform.position, Quaternion.identity));
            if (mapRoom.type == RoomType.BOSS) rendered.Add(Instantiate(markerB, transform.position, Quaternion.identity));
        }
    }

    public void ClearRender()
    {
        foreach (GameObject render in rendered)
        {
            Destroy(render.gameObject);
        }
    }
}
