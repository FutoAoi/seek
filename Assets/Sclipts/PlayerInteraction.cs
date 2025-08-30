using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] Camera _playerCamera;
    [SerializeField] float _interactDistance = 3f;
    [SerializeField] KeyCode _interactKey = KeyCode.F;

    [Header("UIê›íË")]
    [SerializeField] TMP_Text _interactText;

    GameObject _targetItem;
    PickUpItem _pickUpItem;
    Inventory _inventory;
    bool _home = false;
    bool _danjon = false;

    private void Start()
    {
        _inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        CheckItem();
        if(Input.GetKeyDown(_interactKey))
        {
            if(_pickUpItem != null)
            {
                _inventory.AddItem(_pickUpItem.ItemData);
                Destroy(_targetItem);
            }
            if(_home)
            {
                SceneManager.LoadScene(2);
            }
            if (_danjon)
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    private void CheckItem()
    {
        Ray ray = new Ray(_playerCamera.transform.position, _playerCamera.transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, _interactDistance))
        {
            _targetItem = hit.collider.gameObject;
            _pickUpItem = _targetItem.GetComponent<PickUpItem>();
            if( _pickUpItem != null )
            {
                ShowText("[F]" + _pickUpItem.ItemData.ItemName + "ÇèEÇ§");
                return;
            }

            if (hit.collider.CompareTag("Home"))
            {
                ShowText("[F]ãíì_Ç…ñﬂÇÈ");
                _home = true;
                return;
            }

            if (hit.collider.CompareTag("Danjon"))
            {
                ShowText("[F]É_ÉìÉWÉáÉìÇ…êˆÇÈ");
                _danjon = true;
                return;
            }
        }
        _targetItem = null;
        _pickUpItem = null;
        _home = false;
        HideText();
    }

    private void ShowText( string text )
    {
        if(_interactText != null)
        {
            _interactText.text = text;
            _interactText.gameObject.SetActive( true );
        }
    }

    private void HideText()
    {
        if(_interactText != null)
        {
            _interactText.gameObject.SetActive ( false );
        }
    }
}
