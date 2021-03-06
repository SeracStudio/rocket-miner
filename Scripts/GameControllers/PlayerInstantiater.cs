using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInstantiater : NetworkBehaviour
{
    public static PlayerInstantiater RUNNING;
    public Canvas ui;

    public GameObject localPlayer;
    protected override void Awake()
    {
        base.Awake();

        RUNNING = this;

        if (FindObjectOfType<RoomJoiner>().avatarChosen == "arcelia")
        {
            localPlayer = PhotonNetwork.Instantiate("Players/Girl", new Vector3(3, 0, 0), Quaternion.identity);
            Instantiate(Resources.Load("UI/GirlUI"), ui.transform);
        }
        else
        {
            localPlayer = PhotonNetwork.Instantiate("Players/Robot", new Vector3(-3, 0.5f, 0), Quaternion.identity);
            Instantiate(Resources.Load("UI/RobotUI"), ui.transform);
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
