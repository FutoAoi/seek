using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "newItem", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string ItemName;
    public Image UIImage;
    public string description;

    public int value;
}
