using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    [SerializeField] ItemData[] _haveItem = new ItemData[20];
    [SerializeField] InventoryUI _inventoryUI;
    public ItemData[] HaveItem => _haveItem;
    public InventoryUI InventoryUI => _inventoryUI;
    private void Awake()
    {
        _inventoryUI = FindAnyObjectByType<InventoryUI>();
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if(_inventoryUI == null)
        {
            _inventoryUI = FindAnyObjectByType<InventoryUI>();
        }
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

    public void RemoveItem(int index)
    {
        if(HaveItem[index] != null)
        {
            HaveItem[index] = null;
        }
    }

    public bool IsFull()
    {
        for (int i = 0; i < HaveItem.Length; i++)
        {
            if (HaveItem[i] == null) return false;
        }
        return true;
    }
}
