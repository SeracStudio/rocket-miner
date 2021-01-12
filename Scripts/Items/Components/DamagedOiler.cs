using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedOiler : MonoBehaviour
{
    private readonly float timePerSplash = 1f;
    private float timeSinceLastSplash;

    private void Update()
    {
        if(timeSinceLastSplash <= 0)
        {
            PhotonNetwork.Instantiate("OilSplash", new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
            timeSinceLastSplash = timePerSplash;
        }
        else
        {
            timeSinceLastSplash -= Time.deltaTime;
        }
    }
}
