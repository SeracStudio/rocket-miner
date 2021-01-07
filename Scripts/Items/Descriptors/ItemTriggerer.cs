using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTriggerer : MonoBehaviour
{
    public BaseItem item;

    private void OnTriggerEnter(Collider other)
    {
        if (IsTargetValid(other.gameObject))
        {
            item.Use(other.gameObject);
            PhotonNetwork.Destroy(gameObject);
        }
        else
        {
            Debug.Log("No puedes usar ese objeto");
        }
    }

    private bool IsTargetValid(GameObject target)
    {
        return item.target == Target.BOTH || target.CompareTag(item.target.ToString());
    }

    [PunRPC]
    public void LoadItem(string itemName)
    {
        item = Resources.Load(itemName) as BaseItem;
        GetComponentInChildren<SpriteRenderer>().sprite = item.sprite;
    }
}
