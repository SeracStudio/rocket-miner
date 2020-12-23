using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatModifier
{
    public Stat stat;
    public Operation operation;
    public float amount;

    public void Activate(StatsController stat)
    {
        float newValue = OperationFunc.FloatSolve(operation, stat.GetStat(this.stat), amount);
        stat.SetStat(this.stat, newValue);
    }
}
