using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] Image[] _resultsItems = new Image[20];
    [SerializeField] TMP_Text[] _itemText = new TMP_Text[20];
    [SerializeField] TMP_Text _SumMoney;
    [SerializeField] TMP_Text _TotalMoney;
    [SerializeField] TMP_Text _rankText;
    [SerializeField] Animator _animator;

    int _totalvalue = 0;

    void Start()
    {
        _animator = _rankText.GetComponent<Animator>();
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
                _totalvalue += Inventory.Instance.HaveItem[i].Value;
                _TotalMoney.text = _totalvalue.ToString() + "‰~";
                AudioManager.instance.PlaySe(Ses.Money);
                yield return new WaitForSeconds(1);
            }
        }
        if (_totalvalue > 0)
        {
            _rankText.text = "E";
            _rankText.color = Color.red;
        }
        if (_totalvalue > 500)
        {
            _rankText.text = "D";
            _rankText.color = Color.red;
        }
        if(_totalvalue > 1000)
        {
            _rankText.text = "C";
            _rankText.color = Color.red;
        }
        if (_totalvalue > 2000)
        {
            _rankText.text = "B";
            _rankText.color = Color.green;
        }
        if (_totalvalue > 3000)
        {
            _rankText.text = "A";
            _rankText.color = Color.green;
        }
        if (_totalvalue > 5000)
        {
            _rankText.text = "S";
            _rankText.color = Color.yellow;
        }
        _animator.SetBool("rankShow", true);
        AudioManager.instance.StartBgm(Bgms.Title);
    }
}
