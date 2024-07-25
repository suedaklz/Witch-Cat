using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    InventoryItem inventoryItem;

    public InventoryUI inventoryUI;
    public Image itemImage;
    public TextMeshProUGUI itemQuantityText;
    public Button itemRemoveButton;

    void Start()
    {
        if (itemRemoveButton != null)
        {
            itemRemoveButton.onClick.RemoveAllListeners();
            itemRemoveButton.onClick.AddListener(OnRemoveButton);
        }
    }

    public void UpdateSlot(InventoryItem newInventoryItem)
    {
        Debug.Log("Update and assign This Slot : " + newInventoryItem.item.itemType.ToString());
        
        inventoryItem = newInventoryItem;
        itemImage.sprite = inventoryItem.item.icon;
        itemImage.enabled = true;
        itemQuantityText.text = inventoryItem.itemQuantity.ToString();
        itemQuantityText.enabled = inventoryItem.itemQuantity > 1;
        itemRemoveButton.image.enabled = true;
        itemRemoveButton.enabled = true; // Enable the button
    }

    public void ClearSlot()
    {
        if (inventoryItem != null)
            Debug.Log("Clear This Slot : " + inventoryItem.item.itemType.ToString());

        inventoryItem = null;
        itemImage.sprite = null;
        itemImage.enabled = false;
        itemQuantityText.text = "";
        itemQuantityText.enabled = false;
        itemRemoveButton.image.enabled = false;
        itemRemoveButton.enabled = false; // Disable the button

    }

    public void OnRemoveButton() 
    {
        if (inventoryItem != null)
        {
            Debug.Log("Removing This Slot : " + inventoryItem.item.itemType.ToString());

            inventoryUI.inventory.RemoveItem(inventoryItem.item);
        }
        else
        {
            Debug.LogError("No item assigned to this slot.");
        }
    }

}


/*using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Inventory inventory;
    public Image icon;
    InventoryItem item;
    public TextMeshProUGUI quantity;
    public Button removeButton;


    public void UpdateSlot(InventoryItem newItem)
    {
        item = newItem;
        icon.enabled = true;
        icon.sprite = item.item.icon;
        quantity.text = item.quantity.ToString();
        quantity.enabled = item.quantity > 1;
        removeButton.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        quantity.text = "";
        quantity.enabled = false;
        removeButton.enabled = false;

        //if(item != null && item.quantity  > 0)
        //{
        //    quantity.text = item.quantity.ToString();
        //    quantity.enabled = item.quantity > 1;
        //}
        //else
        //{
        //    item = null;
        //    icon.sprite = null;
        //    icon.enabled = false;
        //    quantity.text = "";
        //    quantity.enabled = false;
        //    removeButton.image.enabled = false;
        //    removeButton.enabled = false; // Disable the button
        //}
    }
}*/
