using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractable
{
    [Header("�A�C�e���f�[�^"),SerializeField] ItemData _itemData;
    public ItemData ItemData => _itemData;

    public string GetInteractText()
    {
        if(Inventory.Instance.IsFull())
        {
            return "������������Ȃ�";
        }
        return "[F]" + _itemData.ItemName + "���E��";
    }

    public void Interact(PlayerInteraction player)
    {
        if(!Inventory.Instance.IsFull())
        {
           Destroy(gameObject);
           Inventory.Instance.AddItem(_itemData);
           AudioManager.instance.PlaySe(Ses.Get);
        }
    }
} 
