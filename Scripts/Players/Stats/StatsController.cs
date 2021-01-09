using System;
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

    public Action<Stat, float> OnStatChanged;

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
        //Levantar evento (UI, controlador...)
        statsDict[stat] = value;

        if(CompareTag("GIRL") && stat == Stat.HEALTH && value > 100)
        {
            statsDict[stat] = 100;
        }

        OnStatChanged?.Invoke(stat, value);
        foreach(StatPair listStat in stats)
        {
            if (listStat.stat == stat)
                listStat.value = value;
        }
    }

    public void ChangeStat(Stat stat, float amount)
    {
        SetStat(stat, GetStat(stat) + amount);
    }

    public Dictionary<Stat, float> GetAll()
    {
        return statsDict;
    }
}
