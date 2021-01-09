using System.Collections.Generic;
using UnityEngine;

public enum Target
{
    BOTH,
    GIRL,
    ROBOT,
    Enemy
}

public abstract class BaseItem : ScriptableObject
{
    public Sprite sprite;
    [TextArea]
    public string itemName;
    [TextArea]
    public string itemDescription;
    public Target target;

    private bool IsTargetValid(GameObject target)
    {
        return this.target == Target.BOTH || target.CompareTag(this.target.ToString());
    }

    public void Use(GameObject target)
    {
        if (IsTargetValid(target))
        {
            Activate(target);
        }
    }

    protected abstract void Activate(GameObject target);
}
