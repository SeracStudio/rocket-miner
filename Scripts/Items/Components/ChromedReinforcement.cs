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
        StartCoroutine("PunchInaction", target.GetComponent<Enemy>());
        Rigidbody rb = target.GetComponent<Rigidbody>();
        //Vector3 pushDirection = -rb.velocity;
        Vector3 pushDirection = target.transform.position - transform.position;
        pushDirection = new Vector3(pushDirection.x, 0, pushDirection.z);
        rb.velocity = Vector3.zero;
        rb.AddForce(pushDirection.normalized * force);
    }

    IEnumerator PunchInaction(Enemy enemy)
    {
        enemy.isPushed = true;
        yield return new WaitForSeconds(1.5f);
        enemy.isPushed = false;
    }
}
