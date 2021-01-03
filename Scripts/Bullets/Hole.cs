using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private float deleteTime = 0;
    private float deleteCd = 11;

    private float invCd = 1;
    private float invTime = 0;

    private bool inv = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
                inv=false;
            }
        }
    }

    private void Delete()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Delete();
        }

        if(other.gameObject.tag == "ROBOT" && !inv)
        {
           //Acabar juego 
        }

        if(other.gameObject.tag=="GIRL" && !other.GetComponent<Player>().dash && !inv)
        {
            //Acabar juego
        }
    }
}
