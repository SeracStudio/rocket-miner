using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviourPunCallbacks
{

    public Image imageWaitingRoom;
    public Image imageOtherPlayerWaitingRoom;
    public Image imageGirl;
    public Image imageRobot;
    private string avatarChosen;

  

    public void setRobotAsPlayer()
    {
        avatarChosen = "sora";
    }

    public void setGirlAsPlayer()
    {
        avatarChosen = "arcelia";
    }

    public void loadImageWaitingRoom()
    {
        if(avatarChosen == "sora")
        {
            imageWaitingRoom.sprite = imageRobot.sprite;

            imageOtherPlayerWaitingRoom.sprite = imageGirl.sprite;
            imageOtherPlayerWaitingRoom.SetNativeSize();
            imageOtherPlayerWaitingRoom.transform.localScale = new Vector3(0.4f, 0.4f, 0.0f);
        }
        else if(avatarChosen == "arcelia")
        {
            imageWaitingRoom.sprite = imageGirl.sprite;
            imageWaitingRoom.SetNativeSize();
            imageWaitingRoom.transform.localScale = new Vector3(0.4f, 0.4f, 0.0f);

            imageOtherPlayerWaitingRoom.sprite = imageRobot.sprite;

        }
    }
}
