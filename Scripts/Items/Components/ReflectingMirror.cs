using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectingMirror : MonoBehaviour
{
    public void Effect(GameObject bullet)
    {
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        Vector3 inverse = -rb.velocity;
        rb.velocity = Vector3.zero;
        rb.AddForce(inverse);
    }
}
