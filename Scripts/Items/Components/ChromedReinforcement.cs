using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromedReinforcement : MonoBehaviour
{
    private readonly float force = 5;

    private void Awake()
    {
        //GetComponent<Robot>().OnEnemyPunched += Effect;
    }

    private void Effect(GameObject target)
    {
        Vector3 pushDirection = target.transform.position - transform.position;

        Rigidbody rb = target.GetComponent<Rigidbody>();
        rb.AddForce(pushDirection * force);
    }
}
