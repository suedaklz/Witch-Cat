using System.Collections.Generic;

public class Inventory
{
    public List<InventoryItem> itemList = new List<InventoryItem>();
    public int maxIndexCount = 12;

    public delegate void OnInventoryChanged();
    public event OnInventoryChanged onInventoryChangedCallback;

    public void AddItem(Item item)
    {
        InventoryItem existingItem = itemList.Find(i => i.item.itemType == item.itemType);
        if (existingItem != null)
        {
            existingItem.itemQuantity++;
        }
        else
        {
            if (itemList.Count >= maxIndexCount)
            {
                UnityEngine.Debug.Log("Not Enough room");
                return;
            }
            itemList.Add(new InventoryItem(item));
        }
        PrintList();
        onInventoryChangedCallback?.Invoke();
    }

    public void RemoveItem(Item item)
    {
         InventoryItem existingItem = itemList.Find(i => i.item.itemType == item.itemType);
        if (existingItem != null)
        {
            existingItem.itemQuantity--;
            if (existingItem.itemQuantity <= 0)
            {
                itemList.Remove(existingItem);
                UnityEngine.Debug.Log("Item Removed");
            }
            PrintList();
            onInventoryChangedCallback?.Invoke();
        }
    }

    public void PrintList()
    {
        for(int i = 0; i< itemList.Count; i++)
        {
            //UnityEngine.Debug.Log(itemList[i].item.itemType.ToString());
        }
    }
}