using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyTrinket : MonoBehaviour
{
    public void Effect()
    {
        GetComponent<StatsController>().SetStat(Stat.HEALTH, 100);
        PlayerInstantiater instantiater = FindObjectOfType<PlayerInstantiater>();
        instantiater.PlaceLocalPlayerAt(new Vector3(-3, transform.position.y, 0));
        instantiater.PlacePlayerAt(new Vector3(3, transform.position.y, 0));
        MapController.RUNNING.LoadRoom(MapController.RUNNING.lastRoom);
        Destroy(this);
    }
}
