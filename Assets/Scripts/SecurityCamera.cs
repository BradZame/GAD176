using UnityEngine;

public class SecurityCamera : Security
{
    [SerializeField] private float cameraSwingSpeed = 0.1f;
    [SerializeField] private float cameraSwingAngle = 45f;
    [SerializeField] private float viewDistance = 10f; // How far the camera can see
    [SerializeField] private float rayDownAngle = 90f; // Raycast angle for player detection 

    private float startingCameraRotation;
    private float distanceToPlayer;


    public override void Start()
    {
        base.Start();
        startingCameraRotation = transform.eulerAngles.y;
    }


    public override void Update()
    {
        base.Update();

        Vector3 downwardDirection = Quaternion.Euler(rayDownAngle, 0, 0) * transform.forward; // Calculate the down direction for the raycast 
        RaycastHit hit;


        Ray lineOfSightRay = new Ray(transform.position, downwardDirection); // Creates a ray that checks for player
        Debug.DrawLine(transform.position, transform.position + downwardDirection * viewDistance, Color.red); // Shows that ray in the Scene window

        if (Physics.Raycast(lineOfSightRay, out hit, viewDistance)) // Checks if that ray has hit something 
        {
            if (hit.collider.tag == "Player") // If ray hits player 
            {
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