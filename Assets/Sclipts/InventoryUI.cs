using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] InventorySlot[] _slots = new InventorySlot[20];
    [SerializeField] GameObject _inventry;
    bool _isInventory = false;
    public bool IsInventory => _isInventory;
    private void Start()
    {
        _inventry.SetActive(_isInventory);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            _isInventory = !_isInventory;
            _inventry.SetActive(_isInventory);
            if(_isInventory )
            {
                UIUpdate();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
    public void UIUpdate()
    {
        for(int i = 0; i < _slots.Length; i++)
        {
            _slots[i].SetSlot(Inventory.Instance.HaveItem[i],i);
        }
    }
}
