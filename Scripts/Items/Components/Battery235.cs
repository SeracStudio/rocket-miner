using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery235 : MonoBehaviour
{
    StatsController stats;

    private void Awake()
    {
        stats = GetComponent<StatsController>();
        MapController.RUNNING.OnRoomLoaded += Effect;

        stats.SetStat(Stat.MOV_SPEED, stats.GetStat(Stat.MOV_SPEED) * 1.25f);
        //RESTO DE STATS
    }

    private void Effect()
    {
        float currentHealth = stats.GetStat(Stat.HEALTH);
        stats.SetStat(Stat.HEALTH, currentHealth - 5);
    }
}
