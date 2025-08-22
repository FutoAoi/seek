using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "newItem", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    [SerializeField,Header("�A�C�e����")] private string _itemName;
    [SerializeField,Header("�C���[�W")] private Image _uiImage;
    [SerializeField,Header("����")] private string _description;
    [SerializeField,Header("�l�i")] private int _value;

    public string ItemName => _itemName;
    public Image UIImage => _uiImage;
    public string Description => _description;
    public int Value => _value;

}
