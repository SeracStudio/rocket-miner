using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemList
{
    PARAMEDIC_BACKPACK,
    LUCKY_TRINKET,
    REFLECTING_MIRROR,
    GWEIN_DRILLER,
    EVERGUN_3,
    EVERGUN_LEFT,
    MAGNETGUN,
    TELENERGY,
    DAMAGED_OILER,
    LOOSE_SCREW,
    BATTERY_235,
    CHROMED_REINFORCEMENT,
    THERMIC_ONE,
    ONIS_COIN,
    EMPOWERING_FLINT,
    UNION_BRACELET
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
            case ItemList.EVERGUN_3:
                //target.AddComponent<Disparador>();
                break;
            case ItemList.EVERGUN_LEFT:
                target.AddComponent<EvergunLeft>();
                break;
            case ItemList.MAGNETGUN:
                target.AddComponent<Magnetgun>();
                break;
            case ItemList.TELENERGY:
                //target.AddComponent<Telenergy>();
                PhotonNetwork.Instantiate("TelenergyShield", target.transform.position, Quaternion.identity);
                break;
            case ItemList.DAMAGED_OILER:
                target.AddComponent<DamagedOiler>();
                break;
            case ItemList.LOOSE_SCREW:
                target.AddComponent<LooseScrew>();
                break;
            case ItemList.BATTERY_235:
                target.AddComponent<Battery235>();
                break;
            case ItemList.CHROMED_REINFORCEMENT:
                target.AddComponent<ChromedReinforcement>();
                break;
            case ItemList.THERMIC_ONE:
                target.AddComponent<ThermicOne>();
                break;
            case ItemList.ONIS_COIN:
                target.AddComponent<OnisCoin>();
                break;
            case ItemList.EMPOWERING_FLINT:
                target.AddComponent<EmpoweringFlint>();
                break;
            case ItemList.UNION_BRACELET:
                target.AddComponent<UnionBracelet>();
                break;
        }
    }
}
