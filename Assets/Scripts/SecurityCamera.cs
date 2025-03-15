using UnityEngine;

public class SecurityCamera : Security
{
    public float cameraSwingSpeed = 0.1f;
    public float cameraSwingAngle = 45f;
    public float viewDistance = 10f;
    private float startingCameraRotation;
    private float distanceToPlayer;
    [SerializeField] public float rayDownAngle = 90f;

    public override void Start()
    {
        base.Start();
        startingCameraRotation = transform.eulerAngles.y;
    }


    public override void Update()
    {
        base.Update();
        
        Vector3 downwardDirection = Quaternion.Euler(rayDownAngle, 0, 0) * transform.forward;
        RaycastHit hit;
        
      
        Ray lineOfSightRay = new Ray(transform.position, downwardDirection);
        Debug.DrawLine(transform.position, transform.position + downwardDirection * viewDistance, Color.red);

        if (Physics.Raycast(lineOfSightRay, out hit, viewDistance))
        {
            if (hit.collider.tag == "Player")
            {
                distanceToPlayer = (hit.point - transform.position).magnitude;
                alarmStatus.alarmTripped = true;
                Debug.Log("Player has been seen on camera");
            }
        }
        else
        {
            distanceToPlayer = viewDistance;
        }
        AdjustCameraSwing(distanceToPlayer);
        
    }
    
    private void AdjustCameraSwing(float distanceToPlayer)
    {
        float angle = Mathf.Sin(Time.time * cameraSwingSpeed) * cameraSwingAngle;
        transform.rotation = Quaternion.Euler(0, startingCameraRotation + angle, 0);
    }
}