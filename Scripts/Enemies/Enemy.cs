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

    public bool wall = false;

    public virtual void Update()
    {
        checkStun();
        Rotation();
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

    private void Rotation()
    {
        Vector3 dir = Vector3.RotateTowards(transform.forward, rigidbody.velocity, Time.deltaTime * 10, 0.0f);
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);
    }

    private void checkStun()
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

    public Vector3 getPlayerDirection()
    {
        return (girl.transform.position - this.transform.position);
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

    private void OnCollisionEnter(Collision collision)
    {       
        if (collision.gameObject == girl.gameObject)
        {
            rigidbody.isKinematic = true;
            girl.Attacked(stats.GetStat(Stat.SHOT_DMG));            
        }

        if (collision.gameObject.tag == "Wall")
        {
            wall=true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == girl.gameObject)
        {
            rigidbody.isKinematic = false;          
        }

        if (collision.gameObject.tag == "Wall")
        {
            wall = false;
        }
    }

}
