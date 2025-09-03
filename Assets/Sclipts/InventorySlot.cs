using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour ,IPointerClickHandler
{
    [SerializeField] TMP_Text _itemText;
    [SerializeField] Image _itemImage;

    int _slotIndex;
    ItemData _currentItem;


    public void SetSlot(ItemData item, int index)
    {
        _slotIndex = index;
        _currentItem = item;

        if (item != null)
        {
            _itemText.text = item.ItemName;
            _itemImage.sprite = item.SpriteUI;
        }
        else
        {
            _itemText.text = "";
            _itemImage.sprite = null;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && _currentItem != null)
        {
            Debug.Log(_itemText + "‚ðŽÌ‚Ä‚Ü‚µ‚½");
            Inventory.Instance.RemoveItem(_slotIndex);
            DropItem();
            Inventory.Instance.InventoryUI.UIUpdate();
        }
    }
    private void DropItem()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null && _currentItem.WorldPrefab != null)
        {
            Vector3 dropPos = player.transform.position + player.transform.forward * 2f;
            Instantiate(_currentItem.WorldPrefab, dropPos, Quaternion.identity);
        }
    }
}
