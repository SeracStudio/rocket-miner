using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/StatModifier")]
public class StatModifierItem : BaseItem
{
    [Space(20)]
    public List<StatModifier> effects;

    public void Activate(GameObject target)
    {
        if (this.target != Target.BOTH && !target.CompareTag(this.target.ToString())) return;

        StatsController stats = target.GetComponent<StatsController>();
        foreach(StatModifier effect in effects)
        {
            effect.Activate(stats);
        }
    }
}