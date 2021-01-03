﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject MenuToActivate;
    public Camera camera;
    public Vector3 target;
    private float speed;

    private float startTime;
    private Vector3 initialPos;
    private float distance;

    // Start is called before the first frame update
    void Awake()
    {
        startTime = Time.time;
        initialPos = camera.transform.position;
        distance = Vector3.Distance(target, initialPos);
        speed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {  
    
    }

    public void RemoveMainMenu()
    {
        MainMenu.SetActive(!MainMenu.activeSelf);
        CameraMover.RUNNING.MoveCameraTo(target);
        CameraMover.RUNNING.SetMenu(MenuToActivate, true, 1.0f);
        //MenuToActivate.SetActive(!MenuToActivate.activeSelf);
    }

  
}