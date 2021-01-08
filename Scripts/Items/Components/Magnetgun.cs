using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetgun : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Girl>().magnetGun = true;
    }
}
