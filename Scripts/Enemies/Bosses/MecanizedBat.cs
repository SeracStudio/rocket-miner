using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MecanizedBat : MonoBehaviour
{
    private float changeTargetTime = 0f;
    private float changeTargetCd = 5f;

    private Enemy enemy;
    private MeleeAttack melee;

    private int tgtActual = 0;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        enemy.boss = true;
        melee = GetComponent<MeleeAttack>();
    }


    private void Update()
    {
        changeTargetTime += Time.deltaTime;
        if (changeTargetTime >= changeTargetCd)
        {
            changeTargetTime = 0;

            if (tgtActual == 0)
            {
                enemy.tgt = FindObjectOfType<Girl>();
                melee.tgt = FindObjectOfType<Girl>();
                tgtActual = 1;
                melee.canAttack = true;
            }
            else
            {
                enemy.tgt = FindObjectOfType<Robot>();
                melee.tgt = FindObjectOfType<Robot>();
                tgtActual = 0;
                melee.canAttack = true;
            }
        }
    }

}
