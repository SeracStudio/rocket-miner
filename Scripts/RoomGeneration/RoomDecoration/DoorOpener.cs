using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{

    public void CloseDoor()
    {
        transform.position = new Vector3(transform.position.x, -3, transform.position.z);
        StartCoroutine(LerpToTarget(new Vector3(transform.position.x, 1, transform.position.z), 0.25f));
    }

    public void OpenDoor()
    {
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        StartCoroutine(LerpToTarget(new Vector3(transform.position.x, -3, transform.position.z), 0.5f, () => gameObject.SetActive(false)));
    }

    IEnumerator LerpToTarget(Vector3 target, float time, Action OnComplete = null)
    {
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
