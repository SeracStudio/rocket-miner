using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseScrew : MonoBehaviour
{
    Player player;

    private void Start()
    {
        player = GetComponent<Player>();
        MapController.RUNNING.OnRoomLoaded += Effect;
    }

    private void Effect()
    {
        player.inversed = false;
        if (Random.Range(0, 6) != 0) return;
        player.inversed = true;
    }
}
