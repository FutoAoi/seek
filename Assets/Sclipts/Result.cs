using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] Image[] _resultsItems = new Image[20];
    [SerializeField] TMP_Text[] _itemText = new TMP_Text[20];
    [SerializeField] TMP_Text _SumMoney;
    [SerializeField] TMP_Text _TotalMoney;

    int Totalvalue = 0;

    void Start()
    {
        AudioManager.instance.StartBgm(Bgms.None);
        AudioManager.instance.PlaySe(Ses.Result);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        StartCoroutine(ResultUI());
    }

    IEnumerator ResultUI()
    {
        for(int i = 0; i < Inventory.Instance.HaveItem.Length; i++)
        {
            if(Inventory.Instance.HaveItem[i] != null)
            {
                _resultsItems[i].sprite = Inventory.Instance.HaveItem[i].SpriteUI;
                _itemText[i].text = Inventory.Instance.HaveItem[i].ItemName;
                _SumMoney.text = $"+ {Inventory.Instance.HaveItem[i].Value}‰~";
                Totalvalue += Inventory.Instance.HaveItem[i].Value;
                _TotalMoney.text = Totalvalue.ToString() + "‰~";
                AudioManager.instance.PlaySe(Ses.Money);
                yield return new WaitForSeconds(1);
            }
        }
        AudioManager.instance.StartBgm(Bgms.Title);
    }
}
