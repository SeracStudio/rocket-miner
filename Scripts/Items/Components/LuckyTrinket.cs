using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyTrinket : MonoBehaviour
{
    public void Effect()
    {
        GetComponent<StatsController>().SetStat(Stat.HEALTH, 100);
        MapController.RUNNING.LoadRoom(MapController.RUNNING.lastRoom);
        Destroy(this);
    }
}
