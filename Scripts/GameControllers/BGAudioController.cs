using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAudioController : NetworkBehaviour
{
    public AudioClip ambient, combat;
    public AudioSource source;

    public static BGAudioController INSTANCE;

    protected override void Awake()
    {
        base.Awake();

        INSTANCE = this;
        /*
        MapController.RUNNING.mapRenderer.OnEnemiesRendered += () =>
        {
            TriggerRPC(nameof(ChangeBGMusic), RpcTarget.AllBuffered, 1);
        };
        MapController.RUNNING.OnRoomCleared += () =>
        {
            TriggerRPC(nameof(ChangeBGMusic), RpcTarget.AllBuffered, 0);
        };*/
    }

    [PunRPC]
    public void ChangeBGMusic(int clip)
    {
        if (clip == 0)
            source.clip = ambient;
        else
            source.clip = combat;

        source.Play();
    }
}
