using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractable
{
    [Header("�A�C�e���f�[�^"),SerializeField] ItemData _itemData;
    public ItemData ItemData => _itemData;

    public string GetInteractText()
    {
        return "[F]" + _itemData.ItemName + "���E��";
    }

    public void Interact(PlayerInteraction player)
    {
        Inventory.Instance.AddItem(_itemData);
        Destroy(gameObject);
    }
} 
