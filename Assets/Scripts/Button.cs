using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private AudioClip buttonPressSound;
    private AudioSource audioSource;
    private Vector3 buttonMoveDistance = new Vector3(0, -0.05f, 0); 
    private Vector3 initialPosition; 
    private bool isButtonUp = false;

    void Start()
    {
        initialPosition = button.transform.position;
        audioSource = button.GetComponent<AudioSource>();
    }

    void Update()
    {
        ButtonPressed();
    }

    private void ButtonPressed()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isButtonUp)
            {
                button.transform.position = initialPosition;
            }
            else
            {
                button.transform.position = initialPosition + buttonMoveDistance;
            }

            isButtonUp = !isButtonUp;

            if (audioSource != null && buttonPressSound != null)
            {
                audioSource.Play();
            }
        }
    }
}
