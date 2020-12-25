using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/ComponentAdder")]
public class ComponentAdder : BaseItem
{
    [Space(20)]
    public ItemList component;

    protected override void Activate(GameObject target)
    {
        ItemFunc.AddComponent(target, component);
    }
}