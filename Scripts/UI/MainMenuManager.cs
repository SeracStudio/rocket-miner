using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject MenuToActivate;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveMainMenu()
    {
        MainMenu.SetActive(!MainMenu.activeSelf);
        MenuToActivate.SetActive(!MenuToActivate.activeSelf);

    }
}
