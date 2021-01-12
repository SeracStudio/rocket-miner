using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnExitDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GIRL") || other.CompareTag("ROBOT")) return;

        other.GetComponent<NetworkBehaviour>().TriggerRPC("Destroy");
    }
}
