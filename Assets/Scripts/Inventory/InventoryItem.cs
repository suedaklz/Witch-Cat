public class InventoryItem
{
    public Item item;
    public int itemQuantity;

    public InventoryItem(Item item, int itemQuantity = 1)
    {
        this.item = item;
        this.itemQuantity = itemQuantity;
        SetInventoryItemType(item.itemType);
    }

    void SetInventoryItemType(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Fish:
                item.icon = GameManager.instance.gameAssets.fishSprite;
                break;
            case ItemType.FishBones:
                item.icon = GameManager.instance.gameAssets.fishBonesSprite;
                break;
            case ItemType.Meat:
                item.icon = GameManager.instance.gameAssets.meatSprite;
                break;
            case ItemType.Turkey:
                item.icon = GameManager.instance.gameAssets.turkeySprite;
                break;
            case ItemType.Ham:
                item.icon = GameManager.instance.gameAssets.hamSprite;
                break;
            default:
                break;
        }
    }
}
