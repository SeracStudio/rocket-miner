using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedOiler : MonoBehaviour
{
    private readonly float timePerSplash = 1f;
    private float timeSinceLastSplash;
    private GameObject oilSplash;


    private void Awake()
    {
        oilSplash = Resources.Load("OilSplash") as GameObject;      
    }
    private void Update()
    {
        if(timeSinceLastSplash <= 0)
        {
            Instantiate(oilSplash, transform.position, Quaternion.identity);
            timeSinceLastSplash = timePerSplash;
        }
        else
        {
            timeSinceLastSplash -= Time.deltaTime;
        }
    }
}
