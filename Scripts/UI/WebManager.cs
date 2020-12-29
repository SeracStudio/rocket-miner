using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPortfolio()
    {
        Application.OpenURL("https://seracstudio.github.io/portfolio/");
    }

    public void OpenTwitter()
    {
        Application.OpenURL("https://twitter.com/StudioSerac");
    }
}
