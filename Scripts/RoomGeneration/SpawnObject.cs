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
}
