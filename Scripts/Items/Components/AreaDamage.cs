using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDamage : MonoBehaviour
{
    public List<Target> targets;
    public float damagePerCycle, cycleTime, lifeTime;

    private List<StatsController> currentInArea;
    private float timeSinceLastCycle;
    private Vector3 initialScale;
    private float scaleTimer;

    private void Awake()
    {
        currentInArea = new List<StatsController>();
        initialScale = transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {   
        bool isValid = false;
        foreach(Target target in targets)
        {
            if (other.CompareTag(target.ToString())) isValid = true;
        }
        if (!isValid) return;
        
        currentInArea.Add(other.gameObject.GetComponent<StatsController>());
    }

    private void OnTriggerExit(Collider other)
    {
        StatsController exiter = other.GetComponent<StatsController>();

        if (currentInArea.Contains(exiter))
        {
            currentInArea.Remove(exiter);
        }
    }

    private void Update()
    {
        if(timeSinceLastCycle <= 0)
        {
            foreach(StatsController target in currentInArea)
            {
                target.SetStat(Stat.HEALTH, target.GetStat(Stat.HEALTH) - damagePerCycle);
            }
            timeSinceLastCycle = cycleTime;
        }
        else
        {
            timeSinceLastCycle -= Time.deltaTime;
        }

        scaleTimer += Time.deltaTime;
        transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, scaleTimer / lifeTime);
        if(transform.localScale == Vector3.zero)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
