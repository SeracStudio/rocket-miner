using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : NetworkBehaviour
{
    [PunRPC]
    public void SetActiveState(bool state)
    {
        gameObject.SetActive(state);
    }
}
