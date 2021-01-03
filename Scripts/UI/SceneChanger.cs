using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject[] gameObjects;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
           

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChange()
    {
        foreach(GameObject game in gameObjects) {
            game.transform.SetParent(null);
            DontDestroyOnLoad(game);
        }
        SceneManager.LoadScene(sceneName);

    }
}
