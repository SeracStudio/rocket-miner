﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    private float value;
    void Start()
    {

    }

    public void set(float amount)
    {
        value = amount;
    }

    public float get()
    {
        return value;
    }

    public void change(float amount)
    {
        value += amount;
    }
}
