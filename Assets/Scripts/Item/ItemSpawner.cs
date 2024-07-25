using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Item[] items;
    public int itemCount = 10;
    public GameObject prefab;

    void Start()
    {
        items = Resources.LoadAll<Item>("Inventory/");

        if (items.Length > 0)
        {
            SpawnItems();
        }
        else
        {
            Debug.LogError("No items found in Resources/Inventory/");
        }
    }

    void SpawnItems()
    {
        for (int i = 0; i < itemCount; i++)
        {
            Vector2 randomScreenPosition = new Vector2(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height));
            Vector2 randomWorldPosition = Camera.main.ScreenToWorldPoint(randomScreenPosition);
            Item randomItem = items[Random.Range(0, items.Length)];


            GameObject go = Instantiate(prefab, randomWorldPosition, Quaternion.identity, transform);
            go.GetComponent<ItemWorld>().Type = randomItem.itemType;
        }
    }
}
