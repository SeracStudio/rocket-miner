using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRenderer : MonoBehaviour
{
    public Room room;
    public Room loadedRoom;
    public int roomSize;

    public Action OnEnemiesRendered;

    public readonly List<GameObject> rendered = new List<GameObject>();

    public void Render(MapRoom mapRoom)
    {
        ClearRender();

        transform.position = Vector3.zero;
        loadedRoom = PhotonNetwork.Instantiate("Rooms/" + room.name, transform.position, Quaternion.identity).GetComponent<Room>();
        loadedRoom.SpawnCornerWalls(mapRoom.cornerWallsID);
        rendered.Add(loadedRoom.gameObject);

        PhotonView roomView = loadedRoom.GetComponent<PhotonView>();
        foreach (Direction opening in mapRoom.connections.Keys)
        {
            if ((mapRoom.type == RoomType.NORMAL || mapRoom.type == RoomType.BOSS) && !mapRoom.cleared)
            {
                roomView.RPC("CloseDoor", RpcTarget.AllBuffered, opening);
            }
            else
            {
                roomView.RPC("HideDoor", RpcTarget.AllBuffered, opening);
            }
        }

        StartCoroutine(SpawnEnemiesAfterDelay(mapRoom, 1f));

        if (mapRoom.type == RoomType.BOSS && !mapRoom.cleared)
        {
            EnemySpawnStats enemySpawned = PhotonNetwork.Instantiate("Enemies/EnemySet/" + mapRoom.enemies[0].name,
                    new Vector3(0, 0, 0), Quaternion.identity).GetComponent<EnemySpawnStats>();
            enemySpawned.transform.Rotate(new Vector3(0, 180, 0));
            loadedRoom.spawnedEnemies.Add(enemySpawned);
            rendered.Add(enemySpawned.gameObject);
        }

        if (mapRoom.type == RoomType.TREASURE && !mapRoom.cleared)
        {
            GameObject item = PhotonNetwork.Instantiate("Item", new Vector3(0, 1, 0), Quaternion.identity);
            item.GetComponent<PhotonView>().RPC("LoadItem", RpcTarget.AllBuffered, mapRoom.item.name);
            rendered.Add(item);
        }

        if (mapRoom.type == RoomType.BOSS && mapRoom.cleared)
        {
            rendered.Add(PhotonNetwork.Instantiate("Rooms/FloorStairs", new Vector3(0, 0.01f, 0), Quaternion.identity));
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
            if (render != null)
                PhotonNetwork.Destroy(render.gameObject);
        }
        rendered.Clear();
    }

    IEnumerator SpawnEnemiesAfterDelay(MapRoom mapRoom, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (!mapRoom.cleared && mapRoom.type != RoomType.TREASURE)
            //OnEnemiesRendered?.Invoke();
            BGAudioController.INSTANCE.TriggerRPC("ChangeBGMusic", RpcTarget.AllBuffered, 1);

        if (mapRoom.type == RoomType.NORMAL && !mapRoom.cleared)
        {
            foreach (EnemySpawnStats enemy in mapRoom.enemies)
            {
                float randomX = UnityEngine.Random.Range(-4, 4);
                float randomY = UnityEngine.Random.Range(-4, 4);

                if (enemy.isGuardEye)
                {
                    randomX = 0;
                    randomY = 0;
                }

                EnemySpawnStats enemySpawned = PhotonNetwork.Instantiate("Enemies/EnemySet/" + enemy.name,
                    new Vector3(randomX, 0, randomY), Quaternion.identity).GetComponent<EnemySpawnStats>();
                loadedRoom.spawnedEnemies.Add(enemySpawned);
                rendered.Add(enemySpawned.gameObject);
            }
        }

        foreach (EnemySpawnStats enemy in loadedRoom.spawnedEnemies)
        {
            if (enemy.isSlime) MapController.RUNNING.enemiesLeft += 6;
            enemy.GetComponent<EnemySpawnStats>().OnDeath += MapController.RUNNING.EnemyEliminated;
        }
    }

    public void SpawnStairsAfterDelay(float delay)
    {
        StartCoroutine(SpawnStairsAfterDelayCoroutine(delay));
    }

    IEnumerator SpawnStairsAfterDelayCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        rendered.Add(PhotonNetwork.Instantiate("Rooms/FloorStairs", new Vector3(0, 0.01f, 0), Quaternion.identity));
    }
}
