using UnityEngine;
[CreateAssetMenu(fileName = "newItem", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    [SerializeField,Header("�A�C�e����")] private string _itemName;
    [SerializeField,Header("���A���e�B")]private ItemTier _tier;
    [SerializeField,Header("�C���[�W")] private Sprite _spriteUI;
    [SerializeField,Header("����")] private string _description;
    [SerializeField,Header("�l�i")] private int _value;
    [SerializeField, Header("�A�C�e���̃v���n�u")] GameObject _worldPrefab;

    public string ItemName => _itemName;
    public ItemTier Tier => _tier;
    public Sprite SpriteUI => _spriteUI;
    public string Description => _description;
    public int Value => _value;
    public GameObject WorldPrefab => _worldPrefab;
}
