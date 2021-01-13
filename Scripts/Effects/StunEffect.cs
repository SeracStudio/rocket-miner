using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunEffect : NetworkBehaviour
{
    protected override void Awake()
    {
        base.Awake();
        LeanTween.rotateAround(gameObject, Vector3.forward, 360, 1f).setLoopClamp();
    }

    [PunRPC]
    public void SetActiveState(bool state)
    {
        GetComponent<SpriteRenderer>().enabled = state;
    }
}
