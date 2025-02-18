using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 500f;
    
    float xRotation = 0f;
    float yRotation = 0f;
    
    public float topClamp = -90f;
    public float bottomClamp = 90f;
    
    // Start is called before the first frame update
    void Start()
    {
        //Locks the cursor to the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Getting the mouse inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        //Rotation around the "X" axis (Vertical)
        xRotation -= mouseY;
        
        //Limits how far up and down the player can see   
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);
        yRotation += mouseX;
        
        //Rotation around the "Y" axis (Horizontal) 
        yRotation += mouseX;
        
        //Apply rotations to transform 
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        
    }
}
