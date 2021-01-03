using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnExitDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PhotonNetwork.Destroy(other.gameObject);
    }
}
