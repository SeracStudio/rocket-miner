using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnObject : NetworkBehaviour
{
    public bool onAwake = true;
    public List<GameObject> spawnables;
    public Vector3 rotation;

    public GameObject spawned;
    private int spawnableIndex = 0;

    protected override void Awake()
    {
        base.Awake();
        if (onAwake)
            Spawn();
    }

    [PunRPC]
    public void SetAndSpawn(int index)
    {
        spawnableIndex = index;
        Spawn();
    }

    public void Spawn()
    {
        if (spawnables.Count == 0) return;
        spawned = Instantiate(spawnables[spawnableIndex], transform.position, Quaternion.Euler(rotation));
        spawned.transform.parent = transform;
    }

    public void Destroy()
    {
        PhotonNetwork.Destroy(spawned);
    }

    public void Hide()
    {
        spawned.SetActive(false);
    }

    public void Show()
    {
        spawned.SetActive(true);
    }
}
