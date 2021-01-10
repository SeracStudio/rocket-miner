using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DigMovement : Enemy
{
    public GameObject digSprite;
    public float minDigTime, maxDigTime;
    private float digCurrentTime;

    private bool isUnderground;

    protected override void Awake()
    {
        base.Awake();
        digCurrentTime = UnityEngine.Random.Range(minDigTime, maxDigTime);
    }

    public override void Update()
    {
        base.Update();

        transform.forward = tgt.transform.position - transform.position;

        if (!isUnderground)
        {
            digCurrentTime -= Time.deltaTime;
            if (digCurrentTime < 0)
            {
                digCurrentTime = UnityEngine.Random.Range(minDigTime, maxDigTime);           
                Dig();
            }
        }
    }

    private void Dig()
    {
        stats.SetStat(Stat.ENEMY_CANSHOOT, 0);
        isUnderground = true;
        rigidbody.isKinematic = false;
        StartCoroutine(LerpToTarget(new Vector3(transform.position.x, -4, transform.position.z), 1.5f, () =>
        {
            float randX = UnityEngine.Random.Range(-6, 6);
            float randZ = UnityEngine.Random.Range(-6, 6);
            transform.position = new Vector3(randX, transform.position.y, randZ);

            PhotonNetwork.Instantiate("Bullets/MoleDigMark", new Vector3(randX, 0.01f, randZ), Quaternion.identity);

            StartCoroutine(LerpToTarget(new Vector3(transform.position.x, 0, transform.position.z), 1f, () =>
            {
                stats.SetStat(Stat.ENEMY_CANSHOOT, 1);
                rigidbody.isKinematic = true;
                isUnderground = false;
            }, 1));
        }));
    }

    IEnumerator LerpToTarget(Vector3 target, float time, Action OnComplete = null, float delay = 0)
    {
        yield return new WaitForSeconds(delay);

        float currentTime = 0, value;
        Vector3 starting = transform.position;

        while (currentTime <= time)
        {
            value = currentTime / time;
            currentTime += Time.deltaTime;

            transform.position = Vector3.Lerp(starting, target, value);

            yield return null;
        }

        transform.position = target;
        OnComplete?.Invoke();
    }
}
