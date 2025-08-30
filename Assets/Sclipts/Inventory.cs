using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    [SerializeField] ItemData[] _haveItem = new ItemData[14];
    [SerializeField] InventoryUI _inventoryUI;
    public ItemData[] HaveItem => _haveItem;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        _inventoryUI = FindAnyObjectByType<InventoryUI>();
    }
    public void AddItem(ItemData item)
    {
        for (int i = 0;i < HaveItem.Length;i++)
        {
            if (HaveItem[i] != null) continue;
            HaveItem[i] = item;
            break;
        }
        Debug.Log(item.ItemName + "‚ð“üŽè‚µ‚½");
        _inventoryUI.UIUpdate();
    }
}
