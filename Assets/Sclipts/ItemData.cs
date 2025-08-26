using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "newItem", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    [SerializeField,Header("�A�C�e����")] private string _itemName;
    [SerializeField,Header("�C���[�W")] private Sprite _spriteUI;
    [SerializeField,Header("����")] private string _description;
    [SerializeField,Header("�l�i")] private int _value;

    public string ItemName => _itemName;
    public Sprite SpriteUI => _spriteUI;
    public string Description => _description;
    public int Value => _value;

}
