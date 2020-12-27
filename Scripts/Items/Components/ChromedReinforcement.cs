using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromedReinforcement : MonoBehaviour
{
    private readonly float force = 1000;

    private void Awake()
    {
        GetComponent<Robot>().OnEnemyPunched += Effect;
    }

    private void Effect(GameObject target)
    {
        Rigidbody rb = target.GetComponent<Rigidbody>();
        Vector3 pushDirection = -rb.velocity;
        rb.velocity = Vector3.zero;
        rb.AddForce(pushDirection.normalized * force);
    }
}
