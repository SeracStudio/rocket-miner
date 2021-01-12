using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nomed : MonoBehaviour
{
    private StatsController stats;

    //1
    public Enemy araña;
    public Enemy slime;
    public Enemy murcielago;
    //2
    public Enemy slimeLava;
    //3
    public Enemy abejorro;
    public Enemy murcielagoMecanizado;
    //4
    public Enemy escarabajoExplosivo;
    public Enemy ojoCentinela;

    private int wave = 0;

    private float checkEnemiesCd = 2f;
    private float checkEnemiesTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<StatsController>();
    }

    // Update is called once per frame
    void Update()
    {
        checkEnemies();
    }

    private void checkEnemies()
    {
        checkEnemiesTime += Time.deltaTime;
        if (checkEnemiesTime >= checkEnemiesCd)
        {
            checkEnemiesTime = 0;
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            if (enemies.Length == 1)
            {
                wave++;
                SpawnWave();
            }
        }
    }

    private void SpawnWave()
    {
        switch (wave)
        {
            case 1:
                PhotonNetwork.Instantiate("Enemies/EnemySet/"+ araña.name, new Vector3(Random.Range(-7, 7),0f, Random.Range(-7, 7)), Quaternion.identity);
                PhotonNetwork.Instantiate("Enemies/EnemySet/" + slime.name, new Vector3(Random.Range(-7, 7), 0f, Random.Range(-7, 7)), Quaternion.identity);
                PhotonNetwork.Instantiate("Enemies/EnemySet/" + murcielago.name, new Vector3(Random.Range(-7, 7), 0f, Random.Range(-7, 7)), Quaternion.identity);
                Debug.Log(stats.GetStat(Stat.HEALTH));
                MapController.RUNNING.enemiesLeft += 3;
                break;
            case 2:
                PhotonNetwork.Instantiate("Enemies/EnemySet/" + slimeLava.name, new Vector3(Random.Range(-7, 7), 0f, Random.Range(-7, 7)), Quaternion.identity);
                PhotonNetwork.Instantiate("Enemies/EnemySet/" + murcielago.name, new Vector3(Random.Range(-7, 7), 0f, Random.Range(-7, 7)), Quaternion.identity);
                stats.SetStat(Stat.HEALTH, stats.GetStat(Stat.HEALTH) - 50);
                Debug.Log(stats.GetStat(Stat.HEALTH));
                MapController.RUNNING.enemiesLeft += 2;
                break;
            case 3:
                PhotonNetwork.Instantiate("Enemies/EnemySet/" + abejorro.name, new Vector3(Random.Range(-7, 7), 0f, Random.Range(-7, 7)), Quaternion.identity);
                PhotonNetwork.Instantiate("Enemies/EnemySet/" + murcielagoMecanizado.name, new Vector3(Random.Range(-7, 7), 0f, Random.Range(-7, 7)), Quaternion.identity);
                stats.SetStat(Stat.HEALTH, stats.GetStat(Stat.HEALTH) - 50);
                Debug.Log(stats.GetStat(Stat.HEALTH));
                MapController.RUNNING.enemiesLeft += 2;
                break;
            case 4:
                PhotonNetwork.Instantiate("Enemies/EnemySet/" + escarabajoExplosivo.name, new Vector3(Random.Range(-7, 7), 0f, Random.Range(-7, 7)), Quaternion.identity);
                PhotonNetwork.Instantiate("Enemies/EnemySet/" + ojoCentinela.name, new Vector3(Random.Range(-7, 7), 0f, Random.Range(-7, 7)), Quaternion.identity);
                stats.SetStat(Stat.HEALTH, stats.GetStat(Stat.HEALTH) - 50);
                Debug.Log(stats.GetStat(Stat.HEALTH));
                MapController.RUNNING.enemiesLeft += 2;
                break;
            case 5:
                stats.SetStat(Stat.HEALTH, stats.GetStat(Stat.HEALTH) - 50);
                Destroy(this.gameObject);
                break;
        }
    }
}
