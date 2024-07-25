using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Inventory inventory;
    public InventoryItem inventoryItem;
    public InventoryUI inventoryUI;
    public PlayerHealth playerHealth;
    public int damage;


    void Start()
    {
        
        if (inventoryUI != null)
        {
            inventory = inventoryUI.inventory;
            if (inventory == null)
            {
                Debug.LogError("Inventory not found!");
            }
        }
        /*
        if (inventory == null)
        {
            inventory = FindObjectOfType<InventoryUI>().inventory;
            if (inventory == null)
            {
                Debug.LogError("Inventory not found!");
            }
        }*/
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("object"))
        {
            //Debug.Log("object collision");
            ItemWorld itemWorld = collider.GetComponent<ItemWorld>();

            if (itemWorld != null)
            {
                Item item = ScriptableObject.CreateInstance<Item>();
                item.itemType = itemWorld.Type;
                inventory.AddItem(item);
                Destroy(collider.gameObject);
            }
            else
            {
                Debug.LogWarning("No ItemWorld component found");
            }
        } 
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
