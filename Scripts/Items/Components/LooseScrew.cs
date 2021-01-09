using Photon.Pun;
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
        //player.inversed = false;
        player.TriggerRPC("SetInversedMovement", RpcTarget.All, false);
        if (Random.Range(0, 6) != 0) return;
        //player.inversed = true;
        Debug.Log("INVERSED");
        player.TriggerRPC("SetInversedMovement", RpcTarget.All, true);
    }
}
