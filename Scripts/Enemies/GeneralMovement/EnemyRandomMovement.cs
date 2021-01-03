using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMovement : Enemy
{
    private float directionTime = 0;
    public float directionCd = 1f;
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
            directionTime += Time.deltaTime;
            if (directionTime > directionCd)
            {
                float directionX = Random.Range(-1, 2);
                float directionZ = Random.Range(-1, 2);
                Vector3 direction = new Vector3(directionX, 0, directionZ);
                direction = direction.normalized;
                rigidbody.velocity = new Vector3(direction.x * stats.GetStat(Stat.MOV_SPEED), 0, direction.z * stats.GetStat(Stat.MOV_SPEED));
                directionTime = 0;
            }
        }
        else
        {
            rigidbody.velocity = new Vector3(0, 0, 0);
        }

    }
}
