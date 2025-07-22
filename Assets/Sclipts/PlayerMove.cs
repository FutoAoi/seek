using System.Collections;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float PlayerSpeed = 10f;
    [SerializeField] float PlayerMaxStamina = 10f;

    float PlayerStamina;
    float RunSpeed = 1f;
    float x;
    float z;
    Quaternion rotation;
    Quaternion rotate;
    Vector3 Move;
    Vector3 CameraForward;
    Color DefaultColor;

    bool _isWalk = false;
    bool _isRun = false;
    bool _isTire = false;
    Animator anm;
    Rigidbody rb;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anm = GetComponent<Animator>();
        PlayerStamina = PlayerMaxStamina;
    }

    void Update()
    {
        Mover();
    }

    private void Mover()
    {
        _isWalk = false ;
        _isRun = false ;
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        CameraForward = Camera.main.transform.forward;
        CameraForward.y = 0;
        CameraForward.Normalize();
        RunSpeed = 1f;
        rotation = Quaternion.LookRotation(CameraForward);
        Move = rotation * new Vector3(x, 0, z);

        if (Move.magnitude >= 0.01f)
        {
            rotate = Quaternion.LookRotation(Move);
            _isWalk = true;
        }
        transform.rotation = rotate;
        anm.SetBool("Walk", _isWalk);
        if (_isTire)
        {
            RunSpeed = 0.5f;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            RunSpeed = 2f;
            PlayerStamina -= Time.deltaTime;
            _isRun = true;
            if (PlayerStamina < 0f)
            {
                StartCoroutine("Tired");
                Debug.Log("”æ‚ê‚½");
            }
        }

        if ( !_isRun && PlayerStamina != PlayerMaxStamina)
        {
            PlayerStamina += Time.deltaTime;
            if (PlayerStamina > PlayerMaxStamina)
            {
                PlayerStamina = PlayerMaxStamina;
            }
        }
    }

    private IEnumerator Tired()
    {
        _isTire = true;
        yield return new WaitForSeconds(5f);
        _isTire = false;
    }
    private void FixedUpdate()
    {
        rb.velocity = Move * PlayerSpeed * Time.deltaTime * RunSpeed;
    }
}
