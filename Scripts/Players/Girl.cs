using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : Player
{
    private float dashTime = 0;
    private float nDash = 2;
    private float defTime = 0;

    private float ofTime = 0;
    private bool canShoot=false;

    private float cd=0.75f;

    private bool canBeAttacked = true;
    private float attackedTime = 0;
    private float attackedCd = 1f;

    private BulletController pbc;

    public override void Start()
    {
        base.Start();
        pbc = this.GetComponent<BulletController>();       
    }

    public override void Update()
    {
        base.Update();

        InputsG();
        checkDash();
        checkShoot();
        checkAttacked();
    }

    public override void Attacked(float damageAmount)
    {
        base.Attacked(damageAmount);        
        if (canBeAttacked)
        {
            Debug.Log("Attacked");
            //Reducir vida 
            //Invencibilidad visible de algun modo
            attackedTime += 0.01f;
            canBeAttacked = false;
        }
    }

    private void checkAttacked()
    {
        if (attackedTime > 0)
        {
            attackedTime += Time.deltaTime;
            if (attackedTime > attackedCd)
            {
                attackedTime = 0;
                canBeAttacked = true;
            }
        }
    }

    private void checkShoot()
    {
        if (canShoot)
        {
            ofTime += Time.deltaTime;
            if (ofTime > 1f/stats.GetStat(Stat.SHOTS_P_SECOND))
            {
                ofTime = 0;
                pbc.Shoot(transform.position, getLookingDirection());
            }
        }
    }

    private void checkDash()
    {
        if (dash)
        {
            dashTime += Time.deltaTime;
            if (dashTime > 0.3)
            {
                rigidBody.velocity = new Vector3(rigidBody.velocity.x / 3f, 0, rigidBody.velocity.z / 3f);
                dash = false;
                dashTime = 0;
            }
        }

        if(defTime > 0)
        {
            defTime += Time.deltaTime;
            if (defTime > cd)
            {
                defTime = 0;
                nDash =stats.GetStat(Stat.N_DASH);
            }
        }
    }

    private void InputsG()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && nDash>0)
        {
            nDash -= 1;
            Dash();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            canShoot = true;
            //pbc.Shoot(transform.position, getLookingDirection()) ;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            canShoot = false;
            ofTime = 0;
        }
    }

    private void Dash()
    {
        if (nDash == 0)
        {
            changeDashCd();
        }
        else
        {
            releaseDashCd();
        }
        dash = true;
        defTime += 0.01f;
        rigidBody.velocity = new Vector3(rigidBody.velocity.x*3f,0,rigidBody.velocity.z*3f);
    }

    private void changeDashCd()
    {
        cd = 3;
    }

    private void releaseDashCd()
    {
        cd = stats.GetStat(Stat.DEFENSIVE_CD);
    }

}
