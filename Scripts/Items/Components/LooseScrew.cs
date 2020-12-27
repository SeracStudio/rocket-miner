using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseScrew : MonoBehaviour
{
    private void Awake()
    {
        MapController.RUNNING.OnRoomLoaded += Effect;
    }

    private void Effect()
    {
        //RESTAURAR
        if (Random.Range(0, 6) != 0) return;
        //INVERTIR
    }
}
