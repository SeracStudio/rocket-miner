using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamedicBackpack : MonoBehaviour
{
    StatsController stats;

    private void Awake()
    {
        stats = GetComponent<StatsController>();
        MapController.RUNNING.OnRoomLoaded += Effect;
    }

    private void Effect()
    {
        stats.ChangeStat(Stat.HEALTH, 5);
    }
}
