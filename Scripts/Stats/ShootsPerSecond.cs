using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootsPerSecond : MonoBehaviour
{
    private int value;
    void Start()
    {

    }

    public void set(int amount)
    {
        value = amount;
    }

    public int get()
    {
        return value;
    }

    public void change(int amount)
    {
        value += amount;
    }
}
