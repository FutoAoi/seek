using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float PlayerSpeed = 10f;
    [SerializeField] float PlayerMaxStamina = 10f;
    [SerializeField] GameObject StaminaGauge;
    [SerializeField] GameObject MiniMap;

    float currentStamina;
    float runMultiplier = 1f;
    float staminaMaxScale;

    float x;
    float z;

    Quaternion cameraRotation;
    Quaternion moveRotation;
    Vector3 direction;
    Vector3 cameraForward;

    bool _isWalking = false;
    bool _isRunning = false;
    bool _isTired = false;
    bool _isMap = false;

    GameObject targetItem;
    PickUpItem PickUpItem;
    Inventory Inventory;

    Animator anm;
    Rigidbody rb;

    void Start()
    {
        Inventory = GetComponent<Inventory>();
        rb = GetComponent<Rigidbody>();
        anm = GetComponent<Animator>();
        currentStamina = PlayerMaxStamina;
        staminaMaxScale = StaminaGauge.transform.localScale.x;
    }

    void Update()
    {
        Movement();
        PickUp();
        Map();
    }

    private void Movement()
    {
        _isWalking = false ;
        _isRunning = false ;
        runMultiplier = 1f;

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        cameraRotation = Quaternion.LookRotation(cameraForward);
        direction = cameraRotation * new Vector3(x, 0, z);

        if (direction.magnitude >= 0.1f)
        {
            moveRotation = Quaternion.LookRotation(direction);
            _isWalking = true;
            transform.rotation = moveRotation;
        }

        if (_isTired)
        {
            runMultiplier = 0.5f;
        }

        if (Input.GetKey(KeyCode.LeftShift) && !_isTired)
        {
            runMultiplier = 2f;
            currentStamina -= Time.deltaTime;
            _isRunning = true;
            if (currentStamina < 0f)
            {
                StartCoroutine(Tired());
            }
        }
        else
        {
            if (currentStamina < PlayerMaxStamina)
            {
                currentStamina += Time.deltaTime * 0.8f;
                if (currentStamina > PlayerMaxStamina)
                {
                    currentStamina = PlayerMaxStamina;
                }
            }
        }
        Vector3 scale = StaminaGauge.transform.localScale;
        scale.x = staminaMaxScale * currentStamina / PlayerMaxStamina;
        StaminaGauge.transform.localScale = scale;

        anm.SetBool("Walk", _isWalking);
        anm.SetBool("Run", _isRunning);
    }

    private IEnumerator Tired()
    {
        _isTired = true;
        yield return new WaitForSeconds(5f);
        _isTired = false;
    }

    private void PickUp()
    {
        if (targetItem != null && Input.GetKeyDown(KeyCode.E))
        {
            Inventory.AddItem(PickUpItem.ItemData);
            Destroy(targetItem);
            PickUpItem = null;
            targetItem = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Item"))
        {
            targetItem = other.gameObject;
            PickUpItem = targetItem.GetComponent<PickUpItem>();
            if (PickUpItem != null)
            {
                Debug.Log("近づいたアイテム：" + PickUpItem.ItemData.ItemName);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Item"))
        {
            targetItem = null;
            PickUpItem = null;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = direction * PlayerSpeed * Time.deltaTime * runMultiplier;
    }
    void Map()
    {
        _isMap = false;
        if(Input.GetKey(KeyCode.Tab))
        {
            _isMap = true;
            runMultiplier = 0.2f;
        }
        if(_isMap)
        {
            MiniMap.SetActive(true);
        }
        else
        {
            MiniMap.SetActive(false);
        }
    }
}
