using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "newItem", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    [SerializeField,Header("アイテム名")] private string _itemName;
    [SerializeField,Header("イメージ")] private Sprite _spriteUI;
    [SerializeField,Header("説明")] private string _description;
    [SerializeField,Header("値段")] private int _value;

    public string ItemName => _itemName;
    public Sprite SpriteUI => _spriteUI;
    public string Description => _description;
    public int Value => _value;

}
