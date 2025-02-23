using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject button;
    private Vector3 moveOffset = new Vector3(0, -0.05f, 0); 
    private Vector3 initialPosition; 
    private bool isButtonUp = false;

    void Start()
    {
        
        initialPosition = button.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isButtonUp)
            {
                button.transform.position = initialPosition; // Reset to the initial position
            }
            else
            {
                button.transform.position = initialPosition + moveOffset; // Move by the offset
            }

            isButtonUp = !isButtonUp; // Toggle the button's state
        }
    }
}
