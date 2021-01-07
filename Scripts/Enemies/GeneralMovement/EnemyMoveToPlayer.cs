using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveToPlayer : Enemy
{
    private Vector3 playerDirection;
    private float directionTime=0;
    public float directionCd=0.2f;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (!stunned && canMove)
        {
            playerDirection = getPlayerDirection().normalized;
            directionTime += Time.deltaTime;
            if (directionTime > directionCd)
            {
                rigidbody.velocity = new Vector3(playerDirection.x * stats.GetStat(Stat.MOV_SPEED), 0, playerDirection.z * stats.GetStat(Stat.MOV_SPEED));
                directionTime = 0;
            }
        }
        else
        {
            rigidbody.velocity = new Vector3(0,0,0);
        }
        
    }
}
