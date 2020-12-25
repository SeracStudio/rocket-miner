using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemList
{
    PARAMEDIC_BACKPACK,
    LUCKY_TRINKET,
    REFLECTING_MIRROR,
    GWEIN_DRILLER,
    TELENERGY
}

public static class ItemFunc
{
    public static void AddComponent(GameObject target, ItemList component)
    {
        switch (component)
        {
            case ItemList.PARAMEDIC_BACKPACK:
                target.AddComponent<ParamedicBackpack>();
                break;
            case ItemList.LUCKY_TRINKET:
                target.AddComponent<LuckyTrinket>();
                break;
            case ItemList.REFLECTING_MIRROR:
                target.AddComponent<ReflectingMirror>();
                break;
            case ItemList.GWEIN_DRILLER:
                target.AddComponent<GweinDriller>();
                break;
            case ItemList.TELENERGY:
                target.AddComponent<Telenergy>();
                break;
        }
    }
}
