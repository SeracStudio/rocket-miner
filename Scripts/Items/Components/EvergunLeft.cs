using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvergunLeft : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BulletController>().evergun = true;
    }
}
