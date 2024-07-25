using UnityEngine;
using TMPro;

public class ItemWorld : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private ItemType _type;

    public TextMeshPro itemAmountText;
    public int itemAmount;


    public void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public ItemType Type
    {
        get { return _type; }
        set
        {
            _type = value;
            SetSprite(_type);
        }
    }

    void SetSprite(ItemType type)
    {
        switch (type)
        {
            case ItemType.Fish:
                _spriteRenderer.sprite = GameManager.instance.gameAssets.fishSprite;
                break;
            case ItemType.FishBones:
                _spriteRenderer.sprite = GameManager.instance.gameAssets.fishBonesSprite;
                break;
            case ItemType.Meat:
                _spriteRenderer.sprite = GameManager.instance.gameAssets.meatSprite;
                break;
            case ItemType.Turkey:
                _spriteRenderer.sprite = GameManager.instance.gameAssets.turkeySprite;
                break;
            case ItemType.Ham:
                _spriteRenderer.sprite = GameManager.instance.gameAssets.hamSprite;
                break;
            default: break;

        }

    }
}
