using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermicOne : MonoBehaviour
{
    private bool used;

    private void Awake()
    {
        GetComponent<Robot>().OnEnemyPunched += Effect;
        MapController.RUNNING.OnRoomLoaded += ResetPunch;
    }

    private void Effect(GameObject target)
    {
        if (used) return;

        used = true;
        MapController.RUNNING.EnemyEliminated();
        PhotonNetwork.Destroy(target.gameObject);
    }

    private void ResetPunch()
    {
        used = false;
    }
}
