using UnityEngine;

public enum ItemType
{
    Fish,
    FishBones,
    Meat,
    Turkey,
    Ham
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item: ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public Sprite icon = null;
}

