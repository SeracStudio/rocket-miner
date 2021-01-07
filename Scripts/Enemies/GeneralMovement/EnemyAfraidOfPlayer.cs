using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAfraidOfPlayer : Enemy
{
    private Vector3 playerDirection;
    private float directionTime = 0;
    public float directionCd = 0.2f;
    public float directionRandomCd = 1;

    public bool run = false;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (Vector3.Distance(this.transform.position, tgt.transform.position) < 6)
        {
            run = true;
        }
        else
        {
            run = false;
        }


        if (!stunned && canMove)
        {
            if (run)
            {
                playerDirection = -getPlayerDirection().normalized;
                directionTime += Time.deltaTime;
                if (directionTime > directionCd)
                {
                    rigidbody.velocity = new Vector3(playerDirection.x * stats.GetStat(Stat.MOV_SPEED), 0, playerDirection.z * stats.GetStat(Stat.MOV_SPEED));
                }
            }
            else
            {
                directionTime += Time.deltaTime;
                if (directionTime > directionRandomCd)
                {
                    float directionX = Random.Range(-1, 2);
                    float directionZ = Random.Range(-1, 2);
                    Vector3 direction = new Vector3(directionX, 0, directionZ);
                    direction = direction.normalized;
                    rigidbody.velocity = new Vector3(direction.x * stats.GetStat(Stat.MOV_SPEED), 0, direction.z * stats.GetStat(Stat.MOV_SPEED));
                    directionTime = 0;
                }
            }
            
        }
        else
        {
            rigidbody.velocity = new Vector3(0, 0, 0);
        }

    }
}
