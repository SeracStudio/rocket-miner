using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstantiater : MonoBehaviour
{
    private GameObject localPlayer;
    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            localPlayer = PhotonNetwork.Instantiate("Players/Girl", new Vector3(3, 0.5f, 0), Quaternion.identity);
        }
        else
        {
            localPlayer = PhotonNetwork.Instantiate("Players/Robot", new Vector3(-3, 0.5f, 0), Quaternion.identity);
        }
    }

    public void PlacePlayerAt(Vector3 position)
    {
        GetComponent<PhotonView>().RPC("PlaceLocalPlayerAt", RpcTarget.Others, position);
    }

    [PunRPC]
    public void PlaceLocalPlayerAt(Vector3 position)
    {
        localPlayer.transform.position = position;
    }
}
