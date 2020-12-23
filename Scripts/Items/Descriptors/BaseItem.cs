using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Target
{
    BOTH,
    GIRL,
    ROBOT
}

public abstract class BaseItem : ScriptableObject
{
    [TextArea]
    public string itemName;
    [TextArea]
    public string itemDescription;
    public Target target;
}
