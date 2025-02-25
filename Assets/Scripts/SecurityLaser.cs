using System.Collections.Generic;
using UnityEngine;

public class SecurityLaser : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject laserDiode;
    [SerializeField] private float laserLength = 10f;
    [SerializeField] private bool isLaserOn = true;
    [SerializeField] private int maxBounces = 5;


    private List<Vector3> laserHits;


    void Start()
    {
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        laserHits = new List<Vector3>();
    }


    void Update()
    {
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
            Debug.Log("assign the laser diode");
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


            bool hitSomething = Physics.Raycast(currentPoint, laserDirection, out hitInfo, laserLength);


            if (hitSomething)
            {
                laserHits.Add(hitInfo.point);
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

