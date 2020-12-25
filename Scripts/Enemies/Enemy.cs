using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public StatsController stats;
    public Rigidbody rigidbody;
    public Girl girl;

    public bool stunned;
    private float stunnedCd=1f;
    private float stunnedTime;

    public virtual void Update()
    {
        if (stunned)
        {
            stunnedTime += Time.deltaTime;
            if (stunnedTime > stunnedCd)
            {
                stunned = false;
                stunnedTime = 0;
            }
        }
    }

    public virtual void Start()
    {
        stats = GetComponent<StatsController>();
        rigidbody = GetComponent<Rigidbody>();
        girl = FindObjectOfType<Girl>();

        if (stats.GetStat(Stat.ENEMY_SHIELD) == 1)
        {
            //Poner Escudo visualmente
        }
    }

    public Vector3 getPlayerDirection()
    {
        return (girl.transform.position - this.transform.position).normalized;
    }

    public void Stunned()
    {
        if (stats.GetStat(Stat.ENEMY_SHIELD) == 1)
        {          
            shieldOff();
        }
        else
        {
            stunned = true;
        }
    }

    private void shieldOff()
    {
        //Stat Shield a 0
        //Quitar escudo visualmente
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Bullet" && stats.GetStat(Stat.ENEMY_SHIELD)==0 && other.gameObject.GetComponent<Bullet>().playerShoot==0)
        {
            Destroy(other.gameObject);
            //Reducir vida
            if (stats.GetStat(Stat.HEALTH) <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {       
        if (collision.gameObject == girl.gameObject)
        {
            rigidbody.isKinematic = true;
            girl.Attacked(stats.GetStat(Stat.SHOT_DMG));            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == girl.gameObject)
        {
            rigidbody.isKinematic = false;          
        }
    }

}
