using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    [System.Serializable]
    public class StatPair
    {
        public Stat stat;
        public float value;
    }

    public List<StatPair> stats;
    private Dictionary<Stat, float> statsDict;

    private void Awake()
    {
        statsDict = new Dictionary<Stat, float>();

        foreach (StatPair stat in stats)
        {
            statsDict.Add(stat.stat, stat.value);
        }
    }

    public float GetStat(Stat stat)
    {
        return statsDict[stat];
    }

    public void SetStat(Stat stat, float value)
    {
        statsDict[stat] = value;

        //Levantar evento (UI, controlador...)

        foreach (StatPair listStat in stats)
        {
            if(listStat.stat == stat)
            {
                listStat.value = value;
            }
        }
    }
}
