using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private TMP_Text uiButtonText;
    public string itemName = "";
    public int quantity;
    public bool slotFull;

    public void AddItem(string name, int amount)
    {
        itemName = name;
        quantity += amount;
        slotFull = true;
        UpdateUI();
    }

    private void UpdateUI()
        {
            if (uiButtonText != null)
            {
                string buttonText = itemName + " x" + quantity.ToString();
                uiButtonText.text = buttonText;

            }
        }
    // public void ClearSlot()  // 
    // {
    //     itemName = "";
    //     quantity = 0;
    //     slotFull = false;
    //     if (uiButtonText != null)
    //     {
    //         uiButtonText.text = "";
    //     }
    // }
    
}
