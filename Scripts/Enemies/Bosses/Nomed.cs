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
                Instantiate(araña, new Vector3(Random.Range(-7, 7), 0.5f, Random.Range(-7, 7)), Quaternion.identity);
                Instantiate(slime, new Vector3(Random.Range(-7, 7), 0.5f, Random.Range(-7, 7)), Quaternion.identity);
                Instantiate(murcielago, new Vector3(Random.Range(-7, 7), 0.5f, Random.Range(-7, 7)), Quaternion.identity);
                Debug.Log(stats.GetStat(Stat.HEALTH));
                break;
            case 2:
                Instantiate(slimeLava, new Vector3(Random.Range(-7, 7), 0.5f, Random.Range(-7, 7)), Quaternion.identity);
                Instantiate(murcielago, new Vector3(Random.Range(-7, 7), 0.5f, Random.Range(-7, 7)), Quaternion.identity);
                stats.SetStat(Stat.HEALTH, stats.GetStat(Stat.HEALTH) - 50);
                Debug.Log(stats.GetStat(Stat.HEALTH));
                break;
            case 3:
                Instantiate(abejorro, new Vector3(Random.Range(-7, 7), 0.5f, Random.Range(-7, 7)), Quaternion.identity);
                Instantiate(murcielagoMecanizado, new Vector3(Random.Range(-7, 7), 0.5f, Random.Range(-7, 7)), Quaternion.identity);
                stats.SetStat(Stat.HEALTH, stats.GetStat(Stat.HEALTH) - 50);
                Debug.Log(stats.GetStat(Stat.HEALTH));
                break;
            case 4:
                Instantiate(escarabajoExplosivo, new Vector3(Random.Range(-7, 7), 0.5f, Random.Range(-7, 7)), Quaternion.identity);
                Instantiate(ojoCentinela, new Vector3(Random.Range(-7, 7), 0.5f, Random.Range(-7, 7)), Quaternion.identity);
                stats.SetStat(Stat.HEALTH, stats.GetStat(Stat.HEALTH) - 50);
                Debug.Log(stats.GetStat(Stat.HEALTH));
                break;
            case 5:
                stats.SetStat(Stat.HEALTH, stats.GetStat(Stat.HEALTH) - 50);
                Destroy(this.gameObject);
                break;
        }
    }
}
