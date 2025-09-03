using UnityEngine;

public class FPSController : MonoBehaviour
{
    [Header("カメラ設定")]
    [SerializeField] GameObject _cam;
    [SerializeField] public float Xsensityvity = 3f, Ysensityvity = 3f;
    [SerializeField] float _maxCameraAngle = 90f;

    [Header("プレーヤー設定")]
    [SerializeField] float _playerSpeed = 5f;

    float x, z;
    float xRot, yRot;
    float _clanpYRot;
    //bool _isWalking = false, _isRunnig = false;
    Vector3 _direction;
    Vector3 _cameraForward;
    Quaternion _cameraRot, _playerRot;
    Quaternion _cameraRotate;
    Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _cameraRot = _cam.transform.localRotation;
        _playerRot = this.transform.localRotation;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Xsensityvity != GameManager.Instance.Sens && Ysensityvity != GameManager.Instance.Sens)
        {
            Xsensityvity = GameManager.Instance.Sens;
            Ysensityvity = GameManager.Instance.Sens;
        }
        if (Inventory.Instance == null || Inventory.Instance.InventoryUI == null)
        {
            return;
        }
        if (!Inventory.Instance.InventoryUI.IsInventory)
        {
            FPSCamera();
            Move();
        }
    }

    private void FixedUpdate()
    {
        if (Inventory.Instance == null || Inventory.Instance.InventoryUI == null)
        {
            return;
        }
        if (!Inventory.Instance.InventoryUI.IsInventory)
        {
            _rb.velocity = _direction * _playerSpeed;
        }
    }

    private void Move()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        _cameraForward = _cam.transform.forward;
        _cameraForward.y = 0f;
        _cameraForward.Normalize();

        _cameraRotate = Quaternion.LookRotation(_cameraForward);
        _direction = _cameraRotate * new Vector3(x, 0f, z);
    }

    private void FPSCamera()
    {
        xRot = Input.GetAxis("Mouse X") * Xsensityvity;
        yRot = Input.GetAxis("Mouse Y") * Ysensityvity;

        _clanpYRot -= yRot;
        _clanpYRot = Mathf.Clamp(_clanpYRot, -_maxCameraAngle, _maxCameraAngle);

        _playerRot *= Quaternion.Euler(0f, xRot, 0f);

        _cam.transform.localRotation = Quaternion.Euler(_clanpYRot, 0f, 0f);
        transform.localRotation = _playerRot;
    }
}