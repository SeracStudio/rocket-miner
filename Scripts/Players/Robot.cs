using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : Player
{
    public bool shield=false;
    public float shieldTime = 0;
    private bool canUseShield = true;

    public float punchTime = 0;
    private bool canUsePunch = true;
    public bool punch = false;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();       
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        InputsR();
        checkShield();
        checkPunch();
    }

    public override void FixedUpdate()
    {
        if (!shield)
        {
            base.FixedUpdate();
        }
        else
        {
            rigidBody.velocity = new Vector3(0, 0, 0);
        }
    }

    private void InputsR()
    {
        if (Input.GetKey(KeyCode.LeftShift)&& canUseShield)
        {
            Shield();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            releaseShield();
        }

        if (Input.GetKeyDown(KeyCode.Space)&&canUsePunch)
        {
            Punch();      
        }
    }

    private void Punch()
    {
        punchTime = 0.01f;
        canUsePunch = false;
        punch = true;
    }

    private void checkPunch()
    {
        if (punchTime > 0)
        {
            punchTime += Time.deltaTime;
            if (punchTime > stats.GetStat(Stat.OFFENSIVE_CD))
            {
                canUsePunch = true;
                punchTime = 0;            
            }
            if (punchTime > 0.3)
            {
                punch = false;
            }
        }
    }

    private void checkShield()
    {
        if (shieldTime > 0)
        {
            shieldTime += Time.deltaTime;
            if (shieldTime > stats.GetStat(Stat.DEFENSIVE_CD))
            {
                canUseShield = true;
                shieldTime = 0;
            }
        }
    }

    private void Shield()
    {
        shield = true;
    }

    private void releaseShield()
    {
        shield = false;
        canUseShield = false;
        shieldTime = 0.01f;
    }
}
