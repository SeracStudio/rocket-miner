using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : Player
{
    public int shootsPerSecond=3;
    public int shootDamage=2;
    public int health = 100;

    private int nDash = 2;
    public int nDashDefault = 2;

    private float dashTime = 0;
    private float defTime = 0;

    private float ofTime = 0;
    private bool canShoot=false;

    private BulletController pbc;

    public override void Start()
    {
        base.Start();
        cdOf = 1f / shootsPerSecond;
        cdDef = 0.75f;

        pbc = this.GetComponent<BulletController>();
        pbc.setBasics(15, shootDamage, 1,true);
    }

    public override void Update()
    {
        base.Update();

        InputsG();
        checkDash();
        checkShoot();
    }

    private void checkShoot()
    {
        if (canShoot)
        {
            ofTime += Time.deltaTime;
            if (ofTime > cdOf)
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
            if (defTime > cdDef)
            {
                defTime = 0;
                nDash =nDashDefault;
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
        cdDef = 3;
    }

    private void releaseDashCd()
    {
        cdDef = 0.75f;
    }

    private void changeShootsPerSecond(int increment)
    {
        shootsPerSecond += increment;
        cdOf = 1f / shootsPerSecond;
    }
}
