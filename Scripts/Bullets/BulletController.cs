using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BEffects
{
    NORMAL,
    SLOWNESS,
    POISON,
    EXPLOSION,
    TELE,
    SPECIAL
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
    public bool evergun;

    public List<BulletEffect> bulletEffects;
    public Action<Bullet, Vector3, Vector3> OnBulletShot;

    void Start()
    {
        stats = this.GetComponent<StatsController>();
    }

    public Vector3 dirCalculate(Vector3 pos)
    {
        Vector3 target = new Vector3(0, 0, 0);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Default")))
        {
            if (hit.collider.tag.Equals("Floor") || hit.collider.tag.Equals("Enemy") || hit.collider.tag.Equals("Wall")) ;
            {
                target = hit.point - transform.position;
                return target.normalized;
            }
        }

        return target.normalized;
    }

    public void Shoot(Vector3 pos, Vector3 dirA)
    {
        //Bullet aux = Instantiate(bullet, pos, transform.rotation);      
        Bullet aux = PhotonNetwork.Instantiate("Bullets/" + bullet.name, pos, transform.rotation).GetComponent<Bullet>();
        aux.shootSpeed = stats.GetStat(Stat.SHOT_SPEED);
        aux.damage = stats.GetStat(Stat.SHOT_DMG);
        aux.playerShoot = stats.GetStat(Stat.IS_PLAYER);
        //aux.transform.localScale = new Vector3(stats.GetStat(Stat.SHOT_SIZE), stats.GetStat(Stat.SHOT_SIZE), stats.GetStat(Stat.SHOT_SIZE));
        aux.effects = bulletEffects;
        if (stats.GetStat(Stat.IS_PLAYER) == 0)
        {
            Vector3 dir = dirCalculate(pos);
            if (dir.x != 0 && dir.y != 0 && dir.z != 0)
            {
                aux.dir = dir;
                aux.rain = false;
                if (evergun)
                {
                    //Bullet aux2 = Instantiate(aux, pos, transform.rotation);
                    Bullet aux2 = PhotonNetwork.Instantiate("Bullets/" + bullet.name, pos, transform.rotation).GetComponent<Bullet>();
                    aux2.dir = -dir;
                    aux2.shootSpeed = stats.GetStat(Stat.SHOT_SPEED);
                    aux2.damage = stats.GetStat(Stat.SHOT_DMG);
                    aux2.playerShoot = stats.GetStat(Stat.IS_PLAYER);
                    aux2.effects = bulletEffects;
                    OnBulletShot?.Invoke(aux2, pos, -dir);
                }
            }
            else
            {
                aux.dir = new Vector3(1, 0, 0);
                aux.rain = false;
            }


            OnBulletShot?.Invoke(aux, pos, dir);
        }
        else
        {
            aux.dir = dirA;
            if (this.TryGetComponent(out RockRain r))
            {
                aux.rain = true;
            }
            else
            {
                aux.rain = false;
            }

        }
    }
}
