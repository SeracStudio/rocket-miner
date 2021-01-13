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
        stats.SetStat(Stat.DEFENSIVE_CD, stats.GetStat(Stat.DEFENSIVE_CD) * 1.25f);
        stats.SetStat(Stat.OFFENSIVE_CD, stats.GetStat(Stat.OFFENSIVE_CD) * 1.25f);
        stats.SetStat(Stat.SHOTS_P_SECOND, stats.GetStat(Stat.SHOTS_P_SECOND) * 1.25f);
        stats.SetStat(Stat.SHOT_DMG, stats.GetStat(Stat.SHOT_DMG) * 1.25f);
        //RESTO DE STATS
    }

    private void Effect()
    {
        if (MapController.RUNNING.currentRoom.cleared) return;

        //float currentHealth = stats.GetStat(Stat.HEALTH);
        //stats.SetStat(Stat.HEALTH, currentHealth - 5);
        stats.ChangeStat(Stat.HEALTH, -5);
    }
}
