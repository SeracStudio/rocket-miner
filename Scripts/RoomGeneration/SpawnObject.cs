using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public List<GameObject> spawnables;
    public bool randomize;
    public Vector3 rotation;

    private GameObject spawned;

    private void Awake()
    {
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
        Destroy(spawned);
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
