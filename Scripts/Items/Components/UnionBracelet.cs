using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionBracelet : MonoBehaviour
{
    private StatsController stats;
    private Robot robot;
    private bool isInRange;

    private void Awake()
    {
        stats = GetComponent<StatsController>();
        robot = FindObjectOfType<Robot>();
    }

    private void Update()
    {
        if (Vector3.Distance(robot.transform.position, transform.position) < 5 && !isInRange)
        {
            isInRange = true;
            stats.SetStat(Stat.SHOT_DMG, stats.GetStat(Stat.SHOT_DMG) * 1.5f);
            stats.SetStat(Stat.SHOTS_P_SECOND, stats.GetStat(Stat.SHOTS_P_SECOND) * 2f);
        }

        if (Vector3.Distance(robot.transform.position, transform.position) > 5 && isInRange)
        {
            isInRange = false;
            stats.SetStat(Stat.SHOT_DMG, stats.GetStat(Stat.SHOT_DMG) / 1.5f);
            stats.SetStat(Stat.SHOTS_P_SECOND, stats.GetStat(Stat.SHOTS_P_SECOND) / 2f);
        }
    }
}
