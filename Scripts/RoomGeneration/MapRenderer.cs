using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRenderer : MonoBehaviour
{
    public Room room;
    public Room loadedRoom;
    public int roomSize;

    private readonly List<GameObject> rendered = new List<GameObject>();

    public void Render(MapRoom mapRoom)
    {
        ClearRender();

        transform.position = Vector3.zero;
        loadedRoom = PhotonNetwork.Instantiate("Rooms/" + room.name, transform.position, Quaternion.identity).GetComponent<Room>();
        rendered.Add(loadedRoom.gameObject);

        PhotonView roomView = loadedRoom.GetComponent<PhotonView>();
        foreach (Direction opening in mapRoom.connections.Keys)
        {
            if (mapRoom.type == RoomType.NORMAL && !mapRoom.cleared)
            {
                roomView.RPC("CloseDoor", RpcTarget.AllBuffered, opening);
            }
            else
            {
                roomView.RPC("OpenDoor", RpcTarget.AllBuffered, opening);
            }
        }

        if (!mapRoom.cleared)
        {
            foreach (EnemySpawnStats enemy in mapRoom.enemies)
            {
                float randomX = Random.Range(-9, 9);
                float randomY = Random.Range(-9, 9);

                EnemySpawnStats enemySpawned = PhotonNetwork.Instantiate("Enemies/EnemySet/" + enemy.name,
                    new Vector3(randomX, 0, randomY), Quaternion.identity).GetComponent<EnemySpawnStats>();
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
        }
    }

    public void ClearRender()
    {
        foreach (GameObject render in rendered)
        {
            PhotonNetwork.Destroy(render.gameObject);
        }
        rendered.Clear();
    }
}
