using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private float attackTime=0;
    private float attackCd=0.5f;
    private bool attack=false;

    private float canAttackCd=2f;
    private float canAttackTime=0;
    private bool canAttack = true;

    public List<BulletEffect> attackType;

    private StatsController stats;

    private targetAttack target;
    private Player tgt;

    public float distance;

    void Start()
    {
        target = GetComponent<Enemy>().target;
        stats = GetComponent<StatsController>();
        if (target.target == Target.GIRL)
        {
            tgt = FindObjectOfType<Girl>();
        }
        else
        {
            tgt = FindObjectOfType<Robot>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(tgt.transform.position, transform.position);
        if (distance < 2)
        {
            attack = true;
        }

        checkCanAttack();

        if (attack && canAttack)
        {
            checkAttack();
        }
    }

    private void checkCanAttack()
    {
        if (!canAttack)
        {
            canAttackTime += Time.deltaTime;
            if (canAttackTime > canAttackCd)
            {
                canAttack = true;
                canAttackTime = 0;
            }
        }
    }

    private void checkAttack()
    {
        attackTime += Time.deltaTime;
        if (attackTime > attackCd)
        {
            Attack();
            attackTime = 0;
        }
    }

    private void Attack()
    {
        canAttack = false;
        attack = false;
        if(distance < 2)
        {
            foreach (BulletEffect effect in attackType)
            {
                switch (effect.effect)
                {
                    case (BEffects.NORMAL):
                        tgt.Attacked(stats.GetStat(Stat.SHOT_DMG));
                        break;
                    case (BEffects.POISON):
                        tgt.Poisoned(stats.GetStat(Stat.SHOT_DMG), effect.durationTime);
                        break;
                    case (BEffects.SLOWNESS):
                        tgt.Slowness(stats.GetStat(Stat.SHOT_DMG), effect.durationTime);
                        break;
                }
            }
        }       
    }
}
