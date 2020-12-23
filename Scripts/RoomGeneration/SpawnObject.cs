using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject spawnable;

    private void Awake()
    {
        GameObject spawned = Instantiate(spawnable, transform.position, Quaternion.identity);
        spawned.transform.parent = transform;
    }
}
