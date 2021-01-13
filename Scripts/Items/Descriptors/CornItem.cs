using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornItem : MonoBehaviour
{
    private void Awake()
    {
        MapController.RUNNING.OnRoomLoaded += SelfDestroy;
    }

    public void SelfDestroy()
    {
        MapController.RUNNING.OnRoomLoaded -= SelfDestroy;
        PhotonNetwork.Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("GIRL")) return;

        other.GetComponent<StatsController>().ChangeStat(Stat.HEALTH, 5);
        PhotonNetwork.Destroy(gameObject);
    }
}
