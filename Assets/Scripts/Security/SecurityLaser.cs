using System.Collections.Generic;
using UnityEngine;

public class SecurityLaser : Security
{
    [SerializeField] private LineRenderer lineRenderer; // Reference to the line renderer 
    [SerializeField] private GameObject laserDiode; // Laser origin point
    [SerializeField] private float laserLength = 10f; // How the far laser will travel before bouncing or stopping
    [SerializeField] private LayerMask ignoreLayers; // Layers that dont interact with laser
    private bool isLaserOn = true;
    private int maxBounces = 5; // how many times the laser will bounce
    private List<Vector3> laserHits; // Stores the points where the laser hits 


    public override void Start()
    {
        base.Start();

        // Sets the laser width
        lineRenderer.startWidth = 0.1f; 
        lineRenderer.endWidth = 0.1f; 
        
        laserHits = new List<Vector3>(); // initializes the laserHit list
    }


    public override void Update()
    {
        base.Update();

        if (isLaserOn) // if the laser is on draw it 
        {
            DrawLaser();
        }
    }

    /// <summary>
    /// Toggles the laser on & off
    /// </summary>
    public void ToggleLasers()
    {
        Debug.Log("Toggling laser");
        isLaserOn = !isLaserOn;
        UpdateLaser();
    }

    /// <summary>
    /// Updates the visual state of the laser 
    /// </summary>
    public void UpdateLaser()
    {
        lineRenderer.enabled = isLaserOn; // Enable the line renderer  
        if (isLaserOn)
        {
            DrawLaser();
        }
        else
        {
            lineRenderer.enabled = false; // Disable the line renderer  
        }
    }

    /// <summary>
    /// Draws the laser with bounces
    /// </summary>
    public void DrawLaser()
    {
        if (laserDiode == null)
        {
            Debug.LogError("Assign the laser diode."); // assign the diode in inspector 
            return;
        }

        laserHits.Clear(); // clears any previous points the laser hits 

        Vector3 startPoint = laserDiode.transform.position; // Get the starting point to the laser (Laser diode)  
        Vector3 laserDirection = laserDiode.transform.forward; // Set the direction the laser is facing 

      
        
        laserHits.Add(startPoint); // Add the first point the laser hits to the laserHits list
        Vector3 currentPoint = startPoint; // Sets laser diode as the point of origin 

       
        for (int bounce = 0; bounce < maxBounces; bounce++) // Loops through the lasers max bounce limit 
        {
            RaycastHit hitInfo; // stores information about the object the laser hits 

            bool hitSomething = Physics.Raycast(currentPoint, laserDirection, out hitInfo, laserLength, ~ignoreLayers); // Did the laser hit? 

            if (hitSomething) //  if the laser hit an object 
            {
                laserHits.Add(hitInfo.point); // add the registered hit to the laserHits list
                if (hitInfo.collider.CompareTag("Player")) // if the object it hits is a player 
                {
                    Debug.Log("Laser Hit Player "); 
                    SetAlarmStatus(true);; // Trip the alarm
                    break;
                }

                laserDirection = Vector3.Reflect(laserDirection, hitInfo.normal); // Reflects the laser
                currentPoint = hitInfo.point + (laserDirection * 0.1f);  // adds a slight offset to the laser bounce to prevent it bouncing back 
            }
            else // if the laser doesnt hit anything 
            {
                laserHits.Add(currentPoint + (laserDirection * laserLength)); // Add the last point if no hit
                Debug.Log("Laser didn't hit anything");
                break; // Stop if there's nothing to hit
            }
        }

      
        
        lineRenderer.positionCount = laserHits.Count; // Set the number of positions for the line renderer

        for (int i = 0; i < laserHits.Count; i++)
        {
            lineRenderer.SetPosition(i, laserHits[i]); // Set points for the lasers path
        }

        lineRenderer.enabled = true; // Make sure the laser is visible 
    }
}