using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemTypes
    {
        Key,
        Treasure
    }

    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private string itemName;
    [SerializeField] private int quantity = 1;
    [SerializeField] private ItemTypes itemType;
    private bool itemCollected = false;
    
    // public Sprite itemIcon;       - Not there yet 

    public void CollectItem()
    {
        if (!itemCollected)
        {
            if (inventoryManager != null)
            {
                inventoryManager.AddItem(itemName, quantity);
                itemCollected = true;
               
                if (itemType == ItemTypes.Key)
                {
                    inventoryManager.hasKey = true;
                }
                
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            Debug.Log("Player entered item trigger");
            if (Input.GetKeyDown(KeyCode.E))
            {   
                Debug.Log("Player has pressed E to pickup item");
                CollectItem();
            }
            
        }
    }
}