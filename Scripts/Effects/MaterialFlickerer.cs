using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialFlickerer : NetworkBehaviour
{
    public Material initialMat;
    public Material flickMat;
    public SkinnedMeshRenderer rendererMesh;
    public MeshRenderer otherRendererMesh;

    private Coroutine flicker;

    private int state = 0;

    [PunRPC]
    public void FlickerMat()
    {
        if (flicker != null)
            StopCoroutine(flicker);
        flicker = StartCoroutine(FlickerMatCoroutine(0.5f, 2f));
    }

    IEnumerator FlickerMatCoroutine(float duration, float nSwitch)
    {
        float changeInterval = duration / nSwitch;
        float timeSinceLastChange = changeInterval;
        float totalTime = 0;

        if (otherRendererMesh == null)
        {
            rendererMesh.material = initialMat;
        }
        else
        {
            otherRendererMesh.material = initialMat;
        }

        while (totalTime < duration)
        {
            if (timeSinceLastChange >= changeInterval)
            {
                timeSinceLastChange = 0;

                if (state == 0)
                {
                    if (otherRendererMesh == null)
                    {
                        rendererMesh.material = flickMat;
                    }
                    else
                    {
                        otherRendererMesh.material = flickMat;
                    }

                    state = 1;
                }
                else
                {
                    if (otherRendererMesh == null)
                    {
                        rendererMesh.material = initialMat;
                    }
                    else
                    {
                        otherRendererMesh.material = initialMat;
                    }
                    state = 0;
                }
                //rendererMesh.material = rendererMesh.material == initialMat ? flickMat : initialMat;
            }

            timeSinceLastChange += Time.deltaTime;
            totalTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        if (otherRendererMesh == null)
        {
            rendererMesh.material = initialMat;
        }
        else
        {
            otherRendererMesh.material = initialMat;
        }
    }
}
