using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameAssets gameAssets;
    public GameObject inventoryCanvas;
    public InventoryUI inventoryUI;
    public PlayerManager playerManager;

    private bool _isInventoryOpen = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _isInventoryOpen = !_isInventoryOpen;
            inventoryCanvas.transform.GetChild(0).gameObject.SetActive(_isInventoryOpen);

            inventoryUI.UpdateUI();
        }      
    }

}
