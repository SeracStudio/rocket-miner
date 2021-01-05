using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[System.Serializable]
public class targetAttack
{
    public Target target;
}

public class Enemy : NetworkBehaviour
{
    public StatsController stats;
    public Rigidbody rigidbody;
    public BulletController pbc;

    public bool stunned;
    private float stunnedCd;
    private float stunnedTime;

    private float shootTime = 0;


    public bool wall = false;
    public targetAttack target;
    public Player tgt;
    private Robot robot;

    public virtual void Update()
    {
        if (!isOnMaster) return;

        checkStun();
        checkShoot();
        Rotation();
    }

    public virtual void Start()
    {
        stats = GetComponent<StatsController>();
        rigidbody = GetComponent<Rigidbody>();
        robot = FindObjectOfType<Robot>();
        stunnedCd = robot.stats.GetStat(Stat.STUN_DURATION);

        if (target.target == Target.GIRL)
        {
            tgt = FindObjectOfType<Girl>();
        }
        else
        {
            tgt = FindObjectOfType<Robot>();
        }

        if (stats.GetStat(Stat.ENEMY_SHIELD) == 1)
        {
            //Poner Escudo visualmente
        }

        if (stats.GetStat(Stat.ENEMY_CANSHOOT) == 1)
        {
            pbc = GetComponent<BulletController>();
        }
    }

    private void Rotation()
    {
        Vector3 dir = Vector3.RotateTowards(transform.forward, rigidbody.velocity, Time.deltaTime * 10, 0.0f);
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);
    }

    private void checkStun()
    {
        if (stunned)
        {
            stunnedTime += Time.deltaTime;
            if (stunnedTime > stunnedCd)
            {
                stunned = false;
                stunnedTime = 0;
            }
        }
    }

    private void checkShoot()
    {
        if (!isMine) return;

        if (stats.GetStat(Stat.ENEMY_CANSHOOT) == 1)
        {
            shootTime += Time.deltaTime;
            if (shootTime > stats.GetStat(Stat.OFFENSIVE_CD))
            {
                pbc.Shoot(transform.position, getPlayerDirection().normalized);
                //stunned = true;
                shootTime = 0;
            }
        }
    }

    public Vector3 getPlayerDirection()
    {
        return (tgt.transform.position - this.transform.position);
    }

    public void Stunned()
    {
        if (stats.GetStat(Stat.ENEMY_SHIELD) == 1)
        {
            shieldOff();
        }
        else
        {
            stunned = true;
        }
    }

    private void shieldOff()
    {
        stats.SetStat(Stat.ENEMY_SHIELD, 0);
        //Quitar escudo visualmente
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == tgt.gameObject && target.target == Target.GIRL)
        {
            rigidbody.isKinematic = true;
            tgt.Attacked(stats.GetStat(Stat.SHOT_DMG) / 2);
        }

        if (collision.gameObject.tag == "Wall")
        {
            wall = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == tgt.gameObject && target.target == Target.GIRL)
        {
            rigidbody.isKinematic = false;
        }

        if (collision.gameObject.tag == "Wall")
        {
            wall = false;
        }
    }

}
