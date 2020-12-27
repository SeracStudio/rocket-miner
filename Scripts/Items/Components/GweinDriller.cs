using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GweinDriller : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Robot>().OnShield += Stun;
    }

    private void Stun()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 3f);

        foreach (Collider enemy in colliders)
        {
            if (!enemy.CompareTag("Enemy")) continue;

            enemy.GetComponent<Enemy>().Stunned();
        }
    }
}
