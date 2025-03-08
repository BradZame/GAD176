using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryMenu;
    public bool inventoryOpen;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && inventoryOpen)
        {
        
            Time.timeScale = 1;
            inventoryMenu.SetActive(true);
            inventoryOpen = false;
        }
        
        else if (Input.GetKeyDown(KeyCode.Tab) && !inventoryOpen)
        {
            Time.timeScale = 0;
            inventoryMenu.SetActive(false);
            inventoryOpen = true;
        }
        
        
    }
}
