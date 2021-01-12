using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstantiater : NetworkBehaviour
{
    public static PlayerInstantiater RUNNING;

    public GameObject localPlayer;
    private void Start()
    {
        RUNNING = this;

        if (PhotonNetwork.IsMasterClient)
        {
            localPlayer = PhotonNetwork.Instantiate("Players/Girl", new Vector3(3, 0, 0), Quaternion.identity);
        }
        else
        {
            localPlayer = PhotonNetwork.Instantiate("Players/Robot", new Vector3(-3, 0.5f, 0), Quaternion.identity);
        }
    }

    public bool IsGirl()
    {
        return localPlayer.CompareTag("GIRL");
    }

    public void PlacePlayerAt(Vector3 position)
    {
        TriggerRPC("PlaceLocalPlayerAt", RpcTarget.Others, position);
    }

    [PunRPC]
    public void PlaceLocalPlayerAt(Vector3 position)
    {
        localPlayer.transform.position = position;
    }
}
