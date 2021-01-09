using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectingMirror : MonoBehaviour
{
    public void Effect(GameObject bullet)
    {
        /*
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        Debug.Log(rb.velocity);
        Vector3 inverse = -rb.velocity;
        rb.velocity = Vector3.zero;
        rb.AddForce(inverse);
        Debug.Log(rb.velocity);
        */
        Bullet b = bullet.GetComponent<Bullet>();
        b.dir = -b.dir;
        b.playerShoot = 0;
    }
}
