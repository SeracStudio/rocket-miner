using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public Enemy slime;

    public int level=1;

    private float nextCd = 2;
    private float nextTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nextTime += Time.deltaTime;
        if (nextTime < nextCd)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0f, GetComponent<Rigidbody>().velocity.z);
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }
    }

    public void NextSlime()
    {
        if (level <= 2)
        {
            Enemy aux=Instantiate(slime, transform.position, Quaternion.identity);
            aux.transform.position = new Vector3(aux.transform.position.x, 0, aux.transform.position.z);
            //Ver como spawnean
            Enemy aux2=Instantiate(slime, transform.position, Quaternion.identity);
            aux2.transform.position = new Vector3(aux2.transform.position.x, 0, aux2.transform.position.z);
        }
    }
}
