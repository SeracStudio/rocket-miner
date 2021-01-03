using Photon.Pun;
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

    public bool magnetGun = false;

    private bool canBeAttacked = true;
    private float attackedTime = 0;
    private float attackedCd = 1f;

    private float poisonTime = 0;
    private float poisonEffectTime = 0;
    private bool poison = false;
    private float poisonCd = 0;
    private float poisonEffectCd = 0.2f;
    private float poisonDamage = 5;

    private BulletController pbc;

    public override void Start()
    {
        base.Start();
        pbc = this.GetComponent<BulletController>();
    }

    public override void Update()
    {
        if (!GetComponent<PhotonView>().IsMine) return;

        base.Update();

        InputsG();
        checkDash();
        checkShoot();
        checkAttacked();
        checkPoison();
    }

    public override void Attacked(float damageAmount)
    {    
        if (canBeAttacked || poison)
        {
            base.Attacked(damageAmount);
            Debug.Log("Attacked " + damageAmount);
            stats.SetStat(Stat.HEALTH, OperationFunc.FloatSolve(Operation.SUBTRACT, stats.GetStat(Stat.HEALTH), damageAmount));
            //Invencibilidad visible de algun modo
            attackedTime += 0.01f;
            canBeAttacked = false;
            if (stats.GetStat(Stat.HEALTH) <= 0 && !TryGetComponent(out LuckyTrinket trincket))
            {
                //Acabar el juego
                Destroy(this.gameObject);
            }
            else
            {
                stats.SetStat(Stat.HEALTH, 100);
            }
        }
    }

    public override void Poisoned(float amount)
    {     
        if (canBeAttacked)
        {
            base.Poisoned(amount);
            poisonCd = 1f;
            poison = true;
            poisonDamage = 1f;
            poisonEffectCd = 1f / 15f;
            poisonEffectTime = poisonEffectCd;
        }
    }

    public override void Slowness(float amount, float duration)
    {
        if (canBeAttacked)
        {
            Attacked(amount);
            base.Slowness(amount, duration);
        }
    }

    private void checkPoison()
    {
        if (poison)
        {
            poisonTime += Time.deltaTime;
            poisonEffectTime += Time.deltaTime;
            if (poisonEffectTime >= poisonEffectCd)
            {
                poisonEffectTime = 0;
                Attacked(poisonDamage);
            }
            if (poisonTime >= poisonCd)
            {
                poison = false;
                poisonTime = 0;
                poisonEffectTime = 0;
            }
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
