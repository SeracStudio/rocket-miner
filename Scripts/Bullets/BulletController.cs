﻿using Photon.Pun;
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
    SPECIAL,
    STUN
}

[System.Serializable]
public class BulletEffect
{
    public BEffects effect;
    public float durationTime;

    public override bool Equals(object obj)
    {
        BulletEffect otherEffect = (BulletEffect)obj;
        return effect == otherEffect.effect;
    }
}

public class BulletController : MonoBehaviour
{
    private StatsController stats;
    public Bullet bullet;
    public bool evergun;

    public List<BulletEffect> bulletEffects;
    public Action<Bullet, Vector3, Vector3, List<BulletEffect>> OnBulletShot;

    private FloatingJoystick spinJoystick;

    public Vector3 mousePos;

    void Start()
    {
        spinJoystick = GameObject.Find("DirJoystick").GetComponent<FloatingJoystick>();
        stats = this.GetComponent<StatsController>();
    }

    public Vector3 dirCalculate(Vector3 pos, Vector3 mousePosition)
    {
        Vector3 target = new Vector3(0, 0, 0);
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Default")))
        {
            if (hit.collider.tag.Equals("Floor") || hit.collider.tag.Equals("Enemy") || hit.collider.tag.Equals("Wall")) ;
            {
                target = hit.point - pos;
                return target.normalized;
            }
        }

        return target.normalized;
    }

    public void Shoot(Vector3 pos, Vector3 dirA, bool overrideRain = false)
    {
        Bullet aux = PhotonNetwork.Instantiate("Bullets/" + bullet.name, pos, transform.rotation).GetComponent<Bullet>();
        aux.shootSpeed = stats.GetStat(Stat.SHOT_SPEED);
        aux.damage = stats.GetStat(Stat.SHOT_DMG);
        aux.playerShoot = stats.GetStat(Stat.IS_PLAYER);
        aux.effects = bulletEffects;
        aux.transform.localScale *= stats.GetStat(Stat.SHOT_SIZE);

        if (aux.playerShoot == 1)
        {
            aux.magnetGun = false;
        }

        if (stats.GetStat(Stat.IS_PLAYER) == 0)
        {
            Vector3 dir = dirA.normalized;

            if (!Application.isMobilePlatform)
            {
                //dir = dirCalculate(pos, mousePos);
                //dir = (dirA - pos).normalized;
            }
            else
            {
                //dir = new Vector3(spinJoystick.Horizontal, 0, spinJoystick.Vertical);
            }

            if (dir.x != 0 ||/*&& dir.y != 0 &&*/ dir.z != 0)
            {
                dir.Normalize();
                aux.dir = dir;
                aux.rain = false;
                if (evergun)
                {
                    Bullet aux2 = PhotonNetwork.Instantiate("Bullets/" + bullet.name, pos, transform.rotation).GetComponent<Bullet>();
                    aux2.dir = -dir;
                    aux2.shootSpeed = stats.GetStat(Stat.SHOT_SPEED);
                    aux2.damage = stats.GetStat(Stat.SHOT_DMG);
                    aux2.playerShoot = stats.GetStat(Stat.IS_PLAYER);
                    aux2.effects = bulletEffects;
                    aux2.transform.localScale *= stats.GetStat(Stat.SHOT_SIZE);
                    OnBulletShot?.Invoke(aux2, pos, -dir, bulletEffects);
                }
            }
            else
            {
                aux.dir = new Vector3(1, 0, 0);
                aux.rain = false;
            }


            OnBulletShot?.Invoke(aux, pos, dir, bulletEffects);
        }
        else
        {
            aux.transform.rotation = Quaternion.LookRotation(dirA);
            aux.dir = dirA;
            if (this.TryGetComponent(out RockRain r))
            {
                aux.rain = true;
                if (overrideRain)
                    aux.rain = false;
            }
            else
            {
                aux.rain = false;
            }
        }
    }
}
