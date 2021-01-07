using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockRain : MonoBehaviour
{
    // Start is called before the first frame update

    private BulletController pbc;
    private Enemy enemy;

    public float rainCd;
    private float rainTime;
    private bool rain = true;
    private bool startRain = false;

    public int nRocks = 4;

    private float rainDurationTime = 0;
    public float rainDuration = 2;
    private float rainDurationCd;
    private float globalRainTime=0;

    void Start()
    {
        rainDurationCd = rainDuration / nRocks;
        pbc=this.GetComponent<BulletController>();
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        checkRain();
        Rain();
    }

    private void checkRain()
    {
        if (rain)
        {
            rainTime += Time.deltaTime;
            if (rainTime > rainCd)
            {
                rainTime = 0;
                rain = false;
                startRain = true;
            }
        }
    }

    private void Rain()
    {
        if (startRain)
        {
            rainDurationTime += Time.deltaTime;
            globalRainTime += Time.deltaTime;
            if (rainDurationTime > rainDurationCd)
            {
                InstanceRock();
                rainDurationTime = 0;
            }
            if (globalRainTime > rainDuration)
            {
                rain = true;
                startRain = false;
                globalRainTime = 0;
            }
        }
    }

    private void InstanceRock()
    {
        float x = Random.Range(-8.5f, 8.5f);
        float z = Random.Range(-8.5f, 8.5f);
        pbc.Shoot(new Vector3(x, 10, z), new Vector3(0, -1, 0));
    }
}
