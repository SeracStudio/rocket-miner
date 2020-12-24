using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private StatsController stats;
    public Bullet bullet;

    // Start is called before the first frame update
    void Start()
    {
        stats = this.GetComponent<StatsController>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public Vector2 dirCalculate(Vector3 pos)
    {
        var mousepos = Input.mousePosition;
        mousepos.z = 16;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mousepos).normalized;

        return mousePosition;
    }

    public void Shoot(Vector3 pos, Vector2 dirA)
    {
        Bullet aux=Instantiate(bullet, pos, Quaternion.identity);
        //aux.dir = dirCalculate(pos);
        aux.dir = dirA;
        aux.shootSpeed=stats.GetStat(Stat.SHOT_SPEED);
        aux.damage = stats.GetStat(Stat.SHOT_DMG);
        aux.playerShoot = stats.GetStat(Stat.IS_PLAYER);
        aux.transform.localScale = new Vector3(stats.GetStat(Stat.SHOT_SIZE), stats.GetStat(Stat.SHOT_SIZE), stats.GetStat(Stat.SHOT_SIZE));
    }
}
