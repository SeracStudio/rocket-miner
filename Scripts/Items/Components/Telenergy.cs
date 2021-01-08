using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telenergy : MonoBehaviour
{
    SphereCollider shield;
    private bool isShieldActive;

    private void Awake()
    {
        shield = gameObject.AddComponent<SphereCollider>();
        shield.radius = 2f;
        shield.isTrigger = true;
        MapController.RUNNING.OnRoomLoaded += ResetShield;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bullet")) return;

        if (isShieldActive)
        {
            isShieldActive = false;
            PhotonNetwork.Destroy(other.gameObject);
        }
    }

    private void ResetShield()
    {
        isShieldActive = true;
        Debug.Log(isShieldActive);
    }
}
