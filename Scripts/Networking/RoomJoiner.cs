using Photon.Compression;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomJoiner : MonoBehaviourPunCallbacks
{
    public string gameSceneName;
    public byte neededPlayers;

    //[SerializeField]
    public Text roomName;
    public Text messageWait;
    private string messageStart;
    private string messageEnd;
    public string avatarChosen;
    //private ExitGames.Client.Photon.Hashtable customPropertiesMaster = new ExitGames.Client.Photon.Hashtable();

    public Image otherPlayer;
    public Image playerImage;
    public Image imageGirl;
    public Image imageRobot;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        PhotonNetwork.AutomaticallySyncScene = true;
        /*otherPlayer = FindInActiveObjectByName("Other_Player_Character_Image").GetComponent<Image>();
        playerImage = FindInActiveObjectByName("Character_Selected_image").GetComponent<Image>();
        imageGirl = FindInActiveObjectByName("Arcelia_image").GetComponent<Image>();
        imageRobot = FindInActiveObjectByName("Sora_image").GetComponent<Image>();*/

        messageStart = messageWait.text;
        messageEnd = "La sala está completa. Espera a que el líder empiece la partida.";
    }
    public void CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            Debug.Log("Photon is disconnected");
            return;
        }


        if (roomName.text == "" || ConsistsOfWhiteSpace(roomName.text))
        {
            PhotonNetwork.CreateRoom("Defecto", new Photon.Realtime.RoomOptions() { MaxPlayers = neededPlayers, EmptyRoomTtl = 0 });
        }
        else
        {
            PhotonNetwork.CreateRoom(roomName.text, new Photon.Realtime.RoomOptions() { MaxPlayers = neededPlayers, EmptyRoomTtl = 0 });
        }
        //Debug.Log("Room Created.");
    }
    public bool ConsistsOfWhiteSpace(string s)
    {
        foreach (char c in s)
        {
            if (c != ' ') return false;
        }
        return true;

    }
    public override void OnCreatedRoom()
    {
        messageWait.text = messageStart;
        loadSprite();
        otherPlayer.color = new Color(otherPlayer.color.r, otherPlayer.color.g, otherPlayer.color.b, 0.0f);
        Debug.Log("Room created.");
    }

    public override void OnMasterClientSwitched(Photon.Realtime.Player newMasterClient)
    {
        /*Image aux = otherPlayer;
        otherPlayer = playerImage;
        playerImage = aux;*/
        Debug.Log("El master es " + PhotonNetwork.MasterClient);
    }


    public void loadSprite()
    {
        if (avatarChosen == "sora")
        {
            playerImage.sprite = imageRobot.sprite;
            playerImage.SetNativeSize();

        }
        else if (avatarChosen == "arcelia")
        {
            playerImage.sprite = imageGirl.sprite;
            playerImage.SetNativeSize();
        }
    }

    [PunRPC]
    public void rpcAvatar(string avatar)
    {
        avatarChosen = avatar;
        loadImageWaitingRoom();
    }

    public void loadImageWaitingRoom()
    {
        if (avatarChosen == "sora")
        {
            playerImage.sprite = imageRobot.sprite;
            playerImage.SetNativeSize();

            otherPlayer.sprite = imageGirl.sprite;
            otherPlayer.SetNativeSize();
            //otherPlayer.transform.localScale = new Vector3(0.4f, 0.4f, 0.0f);
        }
        else if (avatarChosen == "arcelia")
        {
            playerImage.sprite = imageGirl.sprite;
            playerImage.SetNativeSize();
            //playerImage.transform.localScale = new Vector3(0.4f, 0.4f, 0.0f);

            otherPlayer.sprite = imageRobot.sprite;
            otherPlayer.SetNativeSize();
        }
        else
        {
            Debug.Log("se cuela");
        }

    }

    [PunRPC]
    public void loadAvatar()
    {
        otherPlayer.color = new Color(otherPlayer.color.r, otherPlayer.color.g, otherPlayer.color.b, 1.0f);
        Debug.Log("RPC Cargar avatar");
    }

    public void changeMessageEnd()
    {
        messageWait.text = messageEnd;
    }

    public void changeMessageStart()
    {
        if (messageWait != null)
            messageWait.text = messageStart;
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            base.photonView.RPC("loadAvatar", RpcTarget.AllBuffered);
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            loadImageWaitingRoom();
            changeMessageEnd();
        }
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        base.photonView.RPC("rpcAvatar", RpcTarget.OthersBuffered, avatarChosen == "sora" ? "arcelia" : "sora");
        loadImageWaitingRoom();
        changeMessageEnd();
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayerGM)
    {
        Debug.Log("Se sale");
        if (otherPlayer != null)
            otherPlayer.color = new Color(otherPlayer.color.r, otherPlayer.color.g, otherPlayer.color.b, 0.0f);
        changeMessageStart();
        PhotonNetwork.CurrentRoom.IsOpen = true;
        PhotonNetwork.CurrentRoom.IsVisible = true;
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Error joining room.");
        CreateRoom();
    }

    public void setAvatarGirl()
    {
        avatarChosen = "arcelia";
    }
    public void setAvatarRobot()
    {
        avatarChosen = "sora";
    }
    public void StartNewGame()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == neededPlayers && PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(gameSceneName);
            Debug.Log("La partida empieza");
        }
        else
        {
            Debug.Log("Faltan jugadores");
        }
    }

    private void Update()
    {

    }
}
