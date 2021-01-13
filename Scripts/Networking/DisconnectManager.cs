using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisconnectManager : MonoBehaviourPunCallbacks
{
    public static DisconnectManager INSTANCE;

    private void Awake()
    {
        INSTANCE = this;
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        Destroy(GameObject.Find("TestConnect_Empty"));
        Destroy(GameObject.Find("RoomManagerPrefab"));
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("UI_Scene");
    }

    [PunRPC]
    public void EndGame()
    {
        if (FindObjectOfType<RoomJoiner>().avatarChosen == "arcelia")
        {
            Destroy(GameObject.Find("GirlUI(Clone)"));
        }
        else
        {
            Destroy(GameObject.Find("RobotUI(Clone)"));
        }
        BlackScreenFader.INSTANCE.gameOverScreen.gameObject.SetActive(true);
        BlackScreenFader.INSTANCE.ReverseFadeTransition(3);

        StartCoroutine("BackToLobby");
    }

    IEnumerator BackToLobby()
    {
        yield return new WaitForSeconds(5);

        Destroy(GameObject.Find("TestConnect_Empty"));
        Destroy(GameObject.Find("RoomManagerPrefab"));
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("UI_Scene");
    }

    [PunRPC]
    public void VictoryEndGame()
    {
        if (FindObjectOfType<RoomJoiner>().avatarChosen == "arcelia")
        {
            Destroy(GameObject.Find("GirlUI(Clone)"));
        }
        else
        {
            Destroy(GameObject.Find("RobotUI(Clone)"));
        }
        BlackScreenFader.INSTANCE.victoryScreen.gameObject.SetActive(true);
        BlackScreenFader.INSTANCE.ReverseFadeTransition(3);

        StartCoroutine("BackToLobby");
    }
}
