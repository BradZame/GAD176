using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public float cameraSwingSpeed = 0.1f;
    public float cameraSwingAngle = 45f;

    private float startingCameraRotation;

    void Start()
    {
        startingCameraRotation = transform.eulerAngles.y;
    }
    
    
    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Sin(Time.time * cameraSwingSpeed) * cameraSwingAngle;
        transform.rotation = Quaternion.Euler(0, startingCameraRotation + angle, 0);
        
    }
}
