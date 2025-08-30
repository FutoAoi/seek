using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] TMP_Text[] _itemTexts = new TMP_Text[14];
    public void UIUpdate()
    {
        for(int i = 0;  i < _itemTexts.Length; i++)
        {
            _itemTexts[i].text = Inventory.Instance.HaveItem[i].ItemName;
        }
    }
}
