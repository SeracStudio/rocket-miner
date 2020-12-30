using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffect : MonoBehaviour
{
    // Start is called before the first frame update

    public float areaRadius=3;
    public float cd=0;
    public float duration=99999;

    private bool area = false;

    private float areaTime=0;
    private float areaDurationTime = 0;

    public BulletEffect effect;

    public StatsController stats;

    private bool attackInRange = false;
    private bool robotProtected = false;

    private Girl girl;

    void Start()
    {
        stats = GetComponent<StatsController>();
        girl = FindObjectOfType<Girl>();
    }

    // Update is called once per frame
    void Update()
    {
        checkAreaCd();
        checkAreaDuration();
        Area();
    }

    private void checkAreaCd()
    {
        if (!area)
        {
            areaTime += Time.deltaTime;
            if (areaTime > cd)
            {
                area = true;
                areaTime = 0;
            }
        }
    }

    private void checkAreaDuration()
    {
        if (area)
        {
            areaDurationTime += Time.deltaTime;
            if (areaDurationTime > duration)
            {
                area = false;
                areaDurationTime = 0;
            }
        }
    }

    private void Area()
    {
        if (area)
        {
            //Switch con los visuales
            attackInRange = false;
            Collider[] colliders = Physics.OverlapSphere(transform.position, areaRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.tag == "Attack")
                {
                    attackInRange = true;
                }
            }
            foreach (Collider collider in colliders)
            {
                if(collider.gameObject.tag=="Attack"|| collider.gameObject.tag == "ROBOT")
                {
                    switch (effect.effect)
                    {
                        case BEffects.NORMAL:
                            collider.GetComponent<Player>().Attacked(stats.GetStat(Stat.SHOT_DMG));
                            break;
                        case BEffects.POISON:
                            collider.GetComponent<Player>().Poisoned(0);
                            break;
                        case BEffects.SLOWNESS:
                            collider.GetComponent<Player>().Slowness(0,effect.durationTime);
                            break;
                        case BEffects.EXPLOSION:
                            if (collider.tag == "ROBOT")
                            {
                                if(!collider.gameObject.GetComponent<Robot>().shield && attackInRange)
                                {
                                    robotProtected = false;
                                }
                                else
                                {
                                    robotProtected = true;
                                }
                            }
                            break;
                    }
                }
            }
            if (effect.effect == BEffects.EXPLOSION)
            {
                GetComponent<EnemySpawnStats>().OnDeath?.Invoke();
                Destroy(this.gameObject);
                if(!robotProtected && attackInRange)
                {
                    girl.Attacked(stats.GetStat(Stat.SHOT_DMG));
                }  
            }
        }
    }
}
