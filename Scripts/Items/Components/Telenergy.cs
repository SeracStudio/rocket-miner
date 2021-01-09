using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telenergy : NetworkBehaviour
{
    SphereCollider shield;
    public MeshRenderer sphere;
    public bool isShieldActive;

    protected override void Awake()
    {
        base.Awake();
        sphere = gameObject.GetComponent<MeshRenderer>();
        gameObject.transform.parent = GameObject.FindGameObjectWithTag("GIRL").transform;

        if (!isOnMaster) return;

        shield = gameObject.AddComponent<SphereCollider>();  
        shield.radius = 0.5f;
        shield.isTrigger = true;
        MapController.RUNNING.OnRoomLoaded += ResetShield;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isOnMaster) return;
        if (!other.CompareTag("Bullet")) return;
        
        Bullet bullet = other.GetComponent<Bullet>();
        if (bullet.playerShoot == 0) return;

        if (isShieldActive)
        {
            isShieldActive = false;
            TriggerRPC(nameof(SetActive), RpcTarget.AllBuffered, false);
            PhotonNetwork.Destroy(other.gameObject);
        }
    }

    private void ResetShield()
    {
        isShieldActive = true;
        TriggerRPC(nameof(SetActive), RpcTarget.AllBuffered, true);
    }

    [PunRPC]
    public void SetActive(bool state)
    {
        sphere.enabled = state;
    }
}
