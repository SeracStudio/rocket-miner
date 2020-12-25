using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GweinDriller : MonoBehaviour
{
    SphereCollider stunArea;
    List<GameObject> nearbyEnemies;

    private void Awake()
    {
        stunArea = gameObject.AddComponent<SphereCollider>();
        stunArea.isTrigger = true;
        stunArea.radius = 3f;
    }

    private void Stun()
    {
        foreach(GameObject enemy in nearbyEnemies)
        {
            /*
             * Movement move = enemy.GetComponent<Movement>();
             * move.canMove = false;
             * move.stunDuration = GetComponent<StatsController>().GetStat(Stat.STUN_DURATION);
             * */
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        nearbyEnemies.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        nearbyEnemies.Remove(other.gameObject);
    }
}
