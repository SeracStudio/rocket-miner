using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    public Camera camera;
    public static CameraMover RUNNING;


    private float startTime;


    // Start is called before the first frame update
    void Awake()
    {
        RUNNING = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCameraTo(Vector3 pos)
    {
        startTime = Time.time;
        StartCoroutine("MoveAnimation", pos);
    }

    IEnumerator MoveAnimation(Vector3 pos)
    {
        Vector3 initialPos = camera.transform.position;
        float percentage = 0f;
        while (percentage < 1f)
        {
            percentage = (Time.time - startTime) / 1.0f;
            camera.transform.position = Vector3.Lerp(initialPos, pos, percentage);
            yield return null;
        }
    }

    public void SetMenu(GameObject menu, bool status, float timing)
    {
        object[] vs = new object[3];
        vs[0] = menu;
        vs[1] = status;
        vs[2] = timing;
        StartCoroutine("SetMenuCoroutine", vs);
    }

    IEnumerator SetMenuCoroutine(object[] vs)
    {
        GameObject menu = vs[0] as GameObject;
        bool status = (bool) vs[1];
        float timing = (float) vs[2];
        
        yield return new WaitForSeconds(timing);
        menu.SetActive(status);
    }
}
