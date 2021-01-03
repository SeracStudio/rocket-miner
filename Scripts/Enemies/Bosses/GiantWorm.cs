using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantWorm : MonoBehaviour
{
    public Hole hole;
    public Bullet bullet;
    public List<BulletEffect> bulletEffects;

    private StatsController stats;

    private float holeTime = 0;
    private float holeCd = 5f;

    private float rockRainTime = 0;
    private float rockRainCd = 20f;

    private 

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<StatsController>();



        
    }

    // Update is called once per frame
    void Update()
    {
        checkHole();
        checkRockRain();
    }

    private void checkHole()
    {
        holeTime += Time.deltaTime;
        if (holeTime >= holeCd)
        {
            holeTime = 0;
            createHole();
        }
    }

    private void checkRockRain()
    {
        rockRainTime += Time.deltaTime;
        if (rockRainTime >= rockRainCd)
        {
            rockRainTime = 0;
            shootRain();
        }
    }

    private void createHole()
    {
        float x = Random.Range(-8, 8);
        float z = Random.Range(-8, 8);
        Instantiate(hole, new Vector3(x, -0.93f, z), Quaternion.identity);
    }

    private void shootRain()
    {
        Hole[]holes = FindObjectsOfType<Hole>();
        for(int i = 0; i < holes.Length; i++)
        {
            Shoot(new Vector3(holes[i].transform.position.x, 10, holes[i].transform.position.z), new Vector3(0, -1, 0));
        }
    }

    private void Shoot(Vector3 pos, Vector3 dirA)
    {
        Bullet aux = Instantiate(bullet, pos, Quaternion.identity);
        aux.shootSpeed = stats.GetStat(Stat.SHOT_SPEED);
        aux.damage = stats.GetStat(Stat.SHOT_DMG);
        aux.playerShoot = stats.GetStat(Stat.IS_PLAYER);
        aux.transform.localScale = new Vector3(stats.GetStat(Stat.SHOT_SIZE), stats.GetStat(Stat.SHOT_SIZE), stats.GetStat(Stat.SHOT_SIZE));
        aux.effects = bulletEffects;
        aux.dir = dirA;
        aux.rain = true;
    }
}
