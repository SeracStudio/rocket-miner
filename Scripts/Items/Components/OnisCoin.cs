using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OnisCoin : MonoBehaviour
{
    private StatsController statsController;
    private List<Stat> stats;
    private Stat stat;
    private float unmodifiedValue;

    private void Awake()
    {
        statsController = GetComponent<StatsController>();
        stats = statsController.GetAll().Keys.ToList();

        MapController.RUNNING.OnRoomLoaded += Effect;
    }

    private void Effect()
    {
        Restore();

        stat = stats.ElementAt(Random.Range(0, stats.Count));
        unmodifiedValue = statsController.GetStat(stat);

        switch(Random.Range(0, 2))
        {
            case 0:
                statsController.SetStat(stat, unmodifiedValue * 1.5f);
                break;
            case 1:
                statsController.SetStat(stat, unmodifiedValue * 0.5f);
                break;
        }
    }

    private void Restore()
    {
        if(unmodifiedValue != 0)
        {
            statsController.SetStat(stat, unmodifiedValue);
        }
    }
}
