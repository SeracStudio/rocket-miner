using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpoweringFlint : MonoBehaviour
{
    private readonly float[] angles = { -30, -15, 15, 30 };
    private StatsController stats;

    private void Awake()
    {
        GetComponent<BulletController>().OnBulletShot += ConeShot;
        stats = GetComponent<StatsController>();
    }

    private void ConeShot(Bullet bullet, Vector3 pos, Vector3 dir, List<BulletEffect> bulletEffects)
    {
        foreach (float angle in angles)
        {
            Bullet aux = PhotonNetwork.Instantiate("Bullets/Bullet", pos, transform.rotation).GetComponent<Bullet>();
            aux.dir = Quaternion.AngleAxis(angle, Vector3.up) * dir;
            aux.transform.Rotate(new Vector3(0, angle, 0));
            aux.shootSpeed = stats.GetStat(Stat.SHOT_SPEED);
            aux.damage = stats.GetStat(Stat.SHOT_DMG);
            aux.playerShoot = stats.GetStat(Stat.IS_PLAYER);
            aux.effects = bulletEffects;
            aux.transform.localScale *= stats.GetStat(Stat.SHOT_SIZE);
        }
    }
}
