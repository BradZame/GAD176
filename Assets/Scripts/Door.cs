using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] protected Transform guard; // Reference to guard 
    [SerializeField] protected Transform player; // Reference to player
    [SerializeField] protected string doorKey = "Key"; // Needed to open the door
    [SerializeField] private InventoryManager playerInventory; // Reference to player inventory
    private Vector3 doorIsClosed; // Door closed position
    private bool doorIsOpen = false; // // Check to see if door is open


    void Start()
    {
        doorIsClosed = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Opens door to guard if alarm is active
    /// Opens door if player has key 
    /// </summary>
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            OpenDoor();
        }

        else if (other.CompareTag("Player"))
        {
            if (playerInventory != null && playerInventory.hasKey)
            {
                OpenDoor();
            }
        }
    }


    /// <summary>
    /// Moves door to open position 
    /// </summary>
    private void OpenDoor()
    {
        if (!doorIsOpen)
        {
            Debug.Log("Opening door");
            transform.position = doorIsClosed + Vector3.up * 4;
            doorIsOpen = true;
        }
    }
}