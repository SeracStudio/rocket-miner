using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BEffects
{
    NORMAL,
    SLOWNESS,
    POISON
}

[System.Serializable]
public class BulletEffect
{
    public BEffects effect;
    public float durationTime;
}

public class BulletController : MonoBehaviour
{
    private StatsController stats;
    public Bullet bullet;

    

    public List<BulletEffect> bulletEffects;

    // Start is called before the first frame update
    void Start()
    {
        stats = this.GetComponent<StatsController>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public Vector3 dirCalculate(Vector3 pos)
    {
        Vector3 target=new Vector3(0,0,0);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Default")))
        {
            if (hit.collider.tag.Equals("Floor"))
            {
                target = hit.point - transform.position;
                return target.normalized;
            }
        }

        return target.normalized;
    }

    public void Shoot(Vector3 pos, Vector3 dirA)
    {
        Bullet aux = Instantiate(bullet, pos, Quaternion.identity);
        aux.shootSpeed = stats.GetStat(Stat.SHOT_SPEED);
        aux.damage = stats.GetStat(Stat.SHOT_DMG);
        aux.playerShoot = stats.GetStat(Stat.IS_PLAYER);
        aux.transform.localScale = new Vector3(stats.GetStat(Stat.SHOT_SIZE), stats.GetStat(Stat.SHOT_SIZE), stats.GetStat(Stat.SHOT_SIZE));
        aux.effects = bulletEffects;
        if (stats.GetStat(Stat.IS_PLAYER) == 0)
        {
            Vector3 dir = dirCalculate(pos);
            if (dir.x != 0 && dir.y != 0 && dir.z != 0)
            {
                aux.dir = dir;
            }
        }
        else
        {
            aux.dir = dirA;
            Debug.Log(dirA);
        }
    }
}
