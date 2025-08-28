using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [Header("アイテムデータ"),SerializeField] ItemData _itemData;

    public ItemData ItemData => _itemData;
} 
