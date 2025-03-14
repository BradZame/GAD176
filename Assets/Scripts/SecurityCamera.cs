using UnityEngine;

public class SecurityCamera : Security
{
    public float cameraSwingSpeed = 0.1f;
    public float cameraSwingAngle = 45f;

    private float startingCameraRotation;


    public override void Start()
    {
        base.Start();
        startingCameraRotation = transform.eulerAngles.y;
    }


    public override void Update()
    {
        base.Update();


        float angle = Mathf.Sin(Time.time * cameraSwingSpeed) * cameraSwingAngle;
        transform.rotation = Quaternion.Euler(0, startingCameraRotation + angle, 0);
    }
}