using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/InstantEffect")]
public abstract class InstantEffect : BaseItem
{
    protected override void Activate(GameObject target)
    {
        Effect(target);
    }

    protected abstract void Effect(GameObject target);
}
