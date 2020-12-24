using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/StatModifier")]
public class StatModifier : BaseItem
{
    [Space(20)]
    public List<StatModifierEffect> modifiers;

    protected override void Activate(GameObject target)
    {
        StatsController stats = target.GetComponent<StatsController>();
        foreach(StatModifierEffect effect in modifiers)
        {
            effect.Activate(stats);
        }
    }
}

public enum Stat
{
    HEALTH,
    MOV_SPEED,
    SHOT_SPEED,
    SHOT_DMG,
    ABILITIES_CD,
    STUN_DURATION
}

[System.Serializable]
public class StatModifierEffect
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