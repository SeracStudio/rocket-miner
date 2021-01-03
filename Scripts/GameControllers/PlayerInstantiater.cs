using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstantiater : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        GameObject localPlayer = PhotonNetwork.Instantiate("Players/" + player.name, new Vector3(0, 0.5f, 0), Quaternion.identity);
        MapController.RUNNING.player = localPlayer.GetComponent<Player>();
    }
}
