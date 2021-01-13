using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnDeath : MonoBehaviour
{
    public GameObject effect;

    private void OnDestroy()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}
