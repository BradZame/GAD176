using System.Collections.Generic;
using UnityEngine;

public class SecurityLaser : Security
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject laserDiode;
    [SerializeField] private float laserLength = 10f;
    [SerializeField] private LayerMask ignoreLayers;
    protected bool isLaserOn = true;
    protected int maxBounces = 5;
    protected List<Vector3> laserHits;


    public override void Start()
    {
        base.Start();

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        laserHits = new List<Vector3>();

        Debug.Log("SecurityLaser Start called.");
    }


    public override void Update()
    {
        base.Update();

        if (isLaserOn)
        {
            DrawLaser();
        }
    }

    public void ToggleLasers()
    {
        isLaserOn = !isLaserOn;
        UpdateLaser();
    }

    private void UpdateLaser()
    {
        lineRenderer.enabled = isLaserOn;
        if (isLaserOn)
        {
            DrawLaser();
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    public void DrawLaser()
    {
        if (laserDiode == null)
        {
            Debug.Log("Assign the laser diode.");
            return;
        }

        laserHits.Clear();

        Vector3 startPoint = laserDiode.transform.position;
        Vector3 laserDirection = laserDiode.transform.forward;

        laserHits.Add(startPoint);

        Vector3 currentPoint = startPoint;

        for (int bounce = 0; bounce < maxBounces; bounce++)
        {
            RaycastHit hitInfo;

            bool hitSomething = Physics.Raycast(currentPoint, laserDirection, out hitInfo, laserLength, ~ignoreLayers);

            if (hitSomething)
            {
                laserHits.Add(hitInfo.point);
                if (hitInfo.collider.CompareTag("Player"))
                {
                    Debug.Log("Laser Hit Player ");
                    alarmStatus.alarmTripped = true;
                    break;
                }

                laserDirection = Vector3.Reflect(laserDirection, hitInfo.normal);
                currentPoint = hitInfo.point + (laserDirection * 0.1f);
            }
            else
            {
                laserHits.Add(currentPoint + (laserDirection * laserLength));
                break;
            }
        }

        lineRenderer.positionCount = laserHits.Count;

        for (int i = 0; i < laserHits.Count; i++)
        {
            lineRenderer.SetPosition(i, laserHits[i]);
        }

        lineRenderer.enabled = true;
    }
}