using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Girl : Player
{
    private float dashTime = 0;
    private float nDash = 2;
    private float defTime = 0;

    private float ofTime = 0;
    private bool canShoot = false;

    private float cd = 0.75f;

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

    public Transform shotSpawnPoint;
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
        checkPoison();
    }

    public override void Attacked(float damageAmount)
    {
        if (canBeAttacked || poison)
        {
            base.Attacked(damageAmount);
            Debug.Log("Attacked " + damageAmount);
            //stats.SetStat(Stat.HEALTH, OperationFunc.FloatSolve(Operation.SUBTRACT, stats.GetStat(Stat.HEALTH), damageAmount));
            stats.ChangeStat(Stat.HEALTH, -damageAmount);
            //Invencibilidad visible de algun modo
            attackedTime += 0.01f;
            canBeAttacked = false;
            if (stats.GetStat(Stat.HEALTH) <= 0)
            {
                if (TryGetComponent(out LuckyTrinket trinket))
                {
                    trinket.Effect();
                }
                else
                {
                    DisconnectManager.INSTANCE.GetComponent<PhotonView>().RPC("EndGame", RpcTarget.AllBuffered);
                    //TriggerRPC(nameof(EndGame), RpcTarget.AllBuffered);
                    PhotonNetwork.Destroy(gameObject);
                }
            }
        }
    }

    public override void Stunned(float amount, float duration)
    {
        Attacked(amount);
        base.Stunned(amount, duration);
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

    private Vector3 shotDir;

    private void checkShoot()
    {
        if (canShoot)
        {
            ofTime += Time.deltaTime;
            if (ofTime > 1f / stats.GetStat(Stat.SHOTS_P_SECOND))
            {
                ofTime = 0;
                pbc.Shoot(shotSpawnPoint.position, shotDir);
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

        if (defTime > 0)
        {
            defTime += Time.deltaTime;
            if (defTime > cd)
            {
                defTime = 0;
                nDash = stats.GetStat(Stat.N_DASH);
            }
        }
    }

    private void InputsG()
    {
        if (!isMine) return;

        if (!Application.isMobilePlatform)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && nDash > 0)
            {
                //Dash();
                TriggerRPC("Dash", RpcTarget.AllBuffered);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                //canShoot = true;
                TriggerRPC("ShootTrue", RpcTarget.MasterClient, getMouse());
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                //canShoot = false;
                //ofTime = 0;
                TriggerRPC("ShootFalse", RpcTarget.MasterClient);
            }
        }
        else
        {
            if (spinJoystick.Vertical != 0.0f && spinJoystick.Horizontal != 0.0f)
            {
                //canShoot = true;
                TriggerRPC(nameof(ShootTrue), RpcTarget.MasterClient, new Vector3(spinJoystick.Horizontal, 0, spinJoystick.Vertical));
            }
            else
            {
                /*
                canShoot = false;
                ofTime = 0;
                */
                TriggerRPC(nameof(ShootFalse), RpcTarget.MasterClient);
            }
        }
    }

    [PunRPC]
    public void ShootTrue(Vector3 mousePos)
    {
        shotDir = mousePos; ;

        canShoot = true;
    }

    [PunRPC]
    public void ShootFalse()
    {
        canShoot = false;
        ofTime = 0;
    }

    [PunRPC]
    public void Dash()
    {
        nDash -= 1;

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
        rigidBody.velocity = new Vector3(rigidBody.velocity.x * 3f, 0, rigidBody.velocity.z * 3f);
    }

    private void changeDashCd()
    {
        cd = 3;
    }

    private void releaseDashCd()
    {
        cd = stats.GetStat(Stat.DEFENSIVE_CD);
    }

    public void DashActionPhone()
    {
        /*
        if (nDash > 0)
        {
            nDash -= 1;
            Dash();
        }*/
        TriggerRPC(nameof(Dash), RpcTarget.MasterClient);
    }


}
