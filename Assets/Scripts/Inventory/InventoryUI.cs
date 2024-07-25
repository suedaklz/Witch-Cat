using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory = new Inventory();
    public Transform itemsParent;

    public InventorySlot[] slots;

    private void OnEnable()
    {
        inventory.onInventoryChangedCallback += UpdateUI;

    }
    private void OnDisable()
    {
        inventory.onInventoryChangedCallback -= UpdateUI;
    }

    void Awake()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void UpdateUI()
    {
        ClearAllSlots();
        Debug.Log("Updating UI");
        for (int i = 0; i < inventory.itemList.Count; i++)
        {
            if (i < inventory.itemList.Count)
            {
                slots[i].UpdateSlot(inventory.itemList[i]);
            }
        }
    }

    private void ClearAllSlots()
    {
        if(slots.Length > 0)
        {
            for (int i = 0; i < slots.Length; i++)
                slots[i].ClearSlot();
        }
    }
}
