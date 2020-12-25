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
        shield.radius = 1f;
        MapController.RUNNING.OnRoomLoaded += ResetShield;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isShieldActive)
        {
            isShieldActive = false;
            Destroy(other);
        }
    }

    private void ResetShield()
    {
        isShieldActive = true;
    }
}
