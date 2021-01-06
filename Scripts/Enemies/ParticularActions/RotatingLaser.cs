using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingLaser : MonoBehaviour
{
    public Material laserMat;
    public float laserWidth, laserSpeed;
    public float laserDamageCD;

    public Vector3 initialVector;
    public List<LayerMask> collideTags;

    private LineRenderer lineRenderer;
    private Vector3 pivot, direction;
    private float currentAngle;
    private float laserDamage, timeSinceLastDamage;

    private void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        pivot = transform.position;
        direction = initialVector;
        laserDamage = transform.parent.GetComponent<StatsController>().GetStat(Stat.SHOT_DMG);

        lineRenderer.material = laserMat;
        lineRenderer.startWidth = lineRenderer.endWidth = laserWidth;
        lineRenderer.SetPosition(0, pivot);
    }

    private void Update()
    {
        currentAngle = Time.deltaTime * laserSpeed;
        direction = Quaternion.AngleAxis(currentAngle, Vector3.up) * direction;
        transform.parent.transform.forward = direction;
        lineRenderer.SetPosition(1, RaycastLaser());
    }

    public Vector3 RaycastLaser()
    {
        float shortestDistance = float.PositiveInfinity;
        RaycastHit shortesHit = new RaycastHit();
        List<RaycastHit> hits = new List<RaycastHit>(collideTags.Count);

        foreach (LayerMask layer in collideTags)
        {
            if (Physics.Raycast(pivot, direction, out RaycastHit hit, 100f, layer))
            {
                hits.Add(hit);
            }
        }

        foreach(RaycastHit v in hits)
        {
            if (Vector3.Distance(pivot, v.point) < shortestDistance)
                shortesHit = v;
        }
        Damage(shortesHit);
        return shortesHit.point;
    }

    public void Damage(RaycastHit hit)
    {
        timeSinceLastDamage += Time.deltaTime;

        if (hit.transform.gameObject.CompareTag("Attack") && timeSinceLastDamage >= laserDamageCD)
        {
            timeSinceLastDamage = 0;
            hit.transform.gameObject.GetComponent<StatsController>().ChangeStat(Stat.HEALTH, -laserDamage);
        }
    }
}
