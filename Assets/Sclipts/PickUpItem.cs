using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractable
{
    [Header("アイテムデータ"),SerializeField] ItemData _itemData;
    public ItemData ItemData => _itemData;

    public string GetInteractText()
    {
        return "[F]" + _itemData.ItemName + "を拾う";
    }

    public void Interact(PlayerInteraction player)
    {
        Inventory.Instance.AddItem(_itemData);
        Destroy(gameObject);
    }
} 
