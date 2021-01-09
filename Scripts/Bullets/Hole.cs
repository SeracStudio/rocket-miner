using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    /*
    private float deleteTime = 0;
    private float deleteCd = 11;
    

    private float invCd = 1;
    private float invTime = 0;

    private bool inv = true;


    void Update()
    {
        
        deleteTime += Time.deltaTime;
        if (deleteTime >= deleteCd)
        {
            Delete();
        }
        

        checkInv();
    }

    private void checkInv()
    {
        if (inv)
        {
            invTime += Time.deltaTime;
            if (invTime >= invCd)
            {
                //Visibilidad de que ha aparecido
                invTime = 0;
                inv = false;
            }
        }
    }

    private void Delete()
    {
        Destroy(gameObject);
    }
    
    */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            //Delete();
            PhotonNetwork.Destroy(gameObject);
        }

        if (other.gameObject.tag == "ROBOT")
        {
            //Acabar juego 
        }

        if (other.gameObject.tag == "GIRL" && !other.GetComponent<Player>().dash)
        {
            //Acabar juego
        }
    }
}
