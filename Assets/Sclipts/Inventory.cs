using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<ItemData> HaveItem = new List<ItemData>();
    public void AddItem(ItemData item)
    {
        HaveItem.Add(item);
        Debug.Log(item.ItemName + "‚ð“üŽè‚µ‚½");
    }
}
