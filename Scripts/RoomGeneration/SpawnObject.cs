using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject spawnable;
    public bool onAwake;

    private void Awake()
    {
        GameObject spawned = Instantiate(spawnable, transform.position, Quaternion.identity);
        spawned.transform.parent = transform;
    }
}
