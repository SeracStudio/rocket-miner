using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopUp : MonoBehaviour
{
    public Text itemName, itemDesc;

    private void Awake()
    {
        MapController.RUNNING.OnRoomLoaded += DestroyItem;
    }

    private void DestroyItem()
    {
        MapController.RUNNING.OnRoomLoaded -= DestroyItem;
        PhotonNetwork.Destroy(gameObject);
    }

    public void SetAndLaunch(string name, string desc)
    {
        itemName.text = name;
        itemDesc.text = desc;
        transform.localScale *= 0;
        LeanTween.scale(gameObject, Vector3.one, 0.5f).setEaseOutBounce();
        StartCoroutine(nameof(RemovePopUp));
    }

    IEnumerator RemovePopUp()
    {
        yield return new WaitForSeconds(5);

        LeanTween.scale(gameObject, Vector3.zero, 0.5f).setEaseOutBounce();

        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
