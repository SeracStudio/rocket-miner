using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public Enemy slime;

    public int level=1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
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
