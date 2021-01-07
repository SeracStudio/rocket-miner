using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnObject : MonoBehaviour
{
    public List<GameObject> spawnables;
    public bool randomize;
    public Vector3 rotation;

    public GameObject spawned;

    public PhotonView photonView;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
        Spawn();
    }

    public void Spawn()
    {
        if (spawnables.Count == 0) return;

        if (randomize)
        {
            spawned = Instantiate(spawnables[Random.Range(0, spawnables.Count)], transform.position, Quaternion.Euler(rotation));
        }
        else
        {
            spawned = Instantiate(spawnables[0], transform.position, Quaternion.Euler(rotation));
        }

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
