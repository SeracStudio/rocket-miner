using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpoweringFlint : MonoBehaviour
{
    private readonly float[] angles = { -30, -15, 15, 30 };

    private void Awake()
    {
        GetComponent<BulletController>().OnBulletShot += ConeShot;
    }

    private void ConeShot(Bullet bullet, Vector3 pos, Vector3 dir)
    {
        foreach(float angle in angles)
        {
            Bullet aux = Instantiate(bullet, pos, transform.rotation);
            aux.dir = Quaternion.AngleAxis(angle, Vector3.up) * dir;
            aux.transform.Rotate(new Vector3(0, angle, 0));
        }
    }
}
