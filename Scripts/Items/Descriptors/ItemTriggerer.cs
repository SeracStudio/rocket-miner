using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTriggerer : MonoBehaviour
{
    public GameObject player;
    public BaseItem item;

    private void Awake()
    {
        item.Use(player.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        item.Use(collision.gameObject);
    }
}
