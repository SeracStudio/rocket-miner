using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantSpider : MonoBehaviour
{
    public Enemy spider;

    public float spawnTime = 0f;
    private float spawnCd = 15f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Enemy>().boss = true;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= spawnCd)
        {
            SpawnSpiders();
            spawnTime = 0f;
        }
    }

    private void SpawnSpiders()
    {
        float x;
        float z;
        for (int i = 0; i < 2; i++)
        {
            x = Random.Range(-4, 4);
            z = Random.Range(-4, 4);
            Enemy aux = PhotonNetwork.Instantiate("Enemies/EnemySet/" + spider.name, new Vector3(x, 0, z), Quaternion.identity).GetComponent<Enemy>();
        }
    }
}
