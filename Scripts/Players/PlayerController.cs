using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviourPunCallbacks
{

    private string avatarChosen = "avatar";
    private ExitGames.Client.Photon.Hashtable customProperties = new ExitGames.Client.Photon.Hashtable();
  

    public void setRobotAsPlayer()
    {
        customProperties[avatarChosen] = "sora";
        PhotonNetwork.LocalPlayer.CustomProperties = customProperties;
    }

    public void setGirlAsPlayer()
    {
        customProperties[avatarChosen] = "arcelia";
        PhotonNetwork.LocalPlayer.CustomProperties = customProperties;
    }

  
}
