using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public List<ItemSlot> PlayerInventory = new List<ItemSlot>();
    public GameObject inventoryUI;
    private bool inventoryOpen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryOpen = !inventoryOpen;
            inventoryUI.SetActive(inventoryOpen);
            Time.timeScale = inventoryOpen ? 0 : 1; // Pause game when inventory is open
        }
    }

    public void AddItem(string itemName, int amount)
    {
        bool itemAdded = false;

        // Check if the item already exists in the inventory
        foreach (var slot in PlayerInventory)
        {
            if (slot.slotFull && slot.itemName == itemName)
            {
                slot.AddItem(itemName, amount); // Add quantity to existing item
                itemAdded = true;
                break;
            }
        }

        if (!itemAdded)
        {
            foreach (var slot in PlayerInventory)
            {
                if (!slot.slotFull)
                {
                    slot.AddItem(itemName, amount);
                    break;
                }
            }
        }
    }

    // public void RemoveItem(string itemName, int amount)
    // {
    //     foreach (var slot in PlayerInventory)
    //     {
    //         if (slot.slotFull && slot.itemName == itemName)
    //         {
    //             slot.quantity -= amount;
    //             if (slot.quantity <= 0)
    //             {
    //                 slot.ClearSlot();
    //             }
    //
    //             break;
    //         }
    //     }
    // }
}