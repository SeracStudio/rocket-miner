using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float lifeSpan;

    private void Update()
    {
        if(lifeSpan < 0)
        {
            PhotonNetwork.Destroy(gameObject);
        }

        lifeSpan -= Time.deltaTime;
    }
}
