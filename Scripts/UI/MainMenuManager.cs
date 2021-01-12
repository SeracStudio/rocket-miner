using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviourPunCallbacks
{

    public GameObject MainMenu;
    public GameObject MenuToActivate;
    public Camera camera;
    public Vector3 target;


    public float speed = 1.0f;

    private float startTime;
    private Vector3 initialPos;
    private float distance;

    // Start is called before the first frame update
    void Awake()
    {
        camera = Camera.main;
        startTime = Time.time;
        initialPos = camera.transform.position;
        distance = Vector3.Distance(target, initialPos);
        
    }

    // Update is called once per frame
    void Update()
    {  
    
    }

    public void RemoveMainMenu()
    {
        MainMenu.SetActive(!MainMenu.activeSelf);
        CameraMover.RUNNING.MoveCameraTo(target);
        CameraMover.RUNNING.SetMenu(MenuToActivate, true, speed);
        //MenuToActivate.SetActive(!MenuToActivate.activeSelf);
    }

    public void RemoveMainMenuPrefab()
    {
        MainMenu = GameObject.Find("Play_Empty");
        MenuToActivate = FindInActiveObjectByName("Waiting_Room_Empty");

        MainMenu.SetActive(!MainMenu.activeSelf);
        MenuToActivate.SetActive(!MenuToActivate.activeSelf);
    }

    private GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }


   
}
