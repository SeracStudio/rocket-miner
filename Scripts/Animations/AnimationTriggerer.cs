using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTriggerer : MonoBehaviour
{
    public Rigidbody rb;
    public Animator anim;

    private void Start()
    {
        if (TryGetComponent(out PhotonView view))
        {
            if (!view.IsMine)
                Destroy(this);
        }
    }

    private void Update()
    {
        if (rb.velocity != Vector3.zero)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }
}
