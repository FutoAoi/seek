using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractable
{
    [Header("アイテムデータ"),SerializeField] ItemData _itemData;
    public ItemData ItemData => _itemData;

    public string GetInteractText()
    {
        if(Inventory.Instance.IsFull())
        {
            return "もう持ちきれない";
        }
        return "[F]" + _itemData.ItemName + "を拾う";
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
