using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnStats : MonoBehaviour
{
    public int danger;
    public Vector2 floors;
    public Action OnDeath;
    public bool isSlime;
    public bool isGuardEye;
}
