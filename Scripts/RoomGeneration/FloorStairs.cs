using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorStairs : NetworkBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!isOnMaster) return;
        if (!other.CompareTag("GIRL") && !other.CompareTag("ROBOT")) return;

        TriggerRPC(nameof(BlackFadeTransition), RpcTarget.AllBuffered);
        MapController.RUNNING.LoadNextMap();
    }

    [PunRPC]
    public void BlackFadeTransition()
    {
        BlackScreenFader.INSTANCE.FadeTransition(1);
    }
}
