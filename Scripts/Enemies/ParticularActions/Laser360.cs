using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser360 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject parent;
    private Robot robot;
    private Girl girl;

    private bool girlInLaser = false;
    private bool robotInLaser = false;
    void Start()
    {
        robot = FindObjectOfType<Robot>();
        girl = FindObjectOfType<Girl>();
    }

    // Update is called once per frame
    void Update()
    {
        parent.transform.RotateAround(parent.transform.position, Vector3.up, 20 * Time.deltaTime);


        if(girlInLaser && robotInLaser)
        {
            if (!robot.shield)
            {
                girl.Attacked(parent.gameObject.GetComponent<StatsController>().GetStat(Stat.SHOT_DMG));
            }
        }

        if(girlInLaser && !robotInLaser)
        {
            girl.Attacked(parent.gameObject.GetComponent<StatsController>().GetStat(Stat.SHOT_DMG));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
            girlInLaser = true;
        }

        if (other.gameObject.tag == "ROBOT")
        {
            robotInLaser = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
            girlInLaser = false;
        }

        if (other.gameObject.tag == "ROBOT")
        {
            robotInLaser = false;
        }
    }
}
