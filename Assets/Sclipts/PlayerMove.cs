using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float PlayerSpeed = 10f;
    [SerializeField] float RotateSpeed = 10f;

    float x;
    float z;
    Quaternion rotation;
    Quaternion rotate;
    Vector3 Move;

    bool _iswalk = false;
    Animator anm;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anm = GetComponent<Animator>();
    }

    void Update()
    {
        Mover();
    }

    private void Mover()
    {
        _iswalk = false ;
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 CameraForward = Camera.main.transform.forward;
        CameraForward.y = 0;
        CameraForward.Normalize();

        if (CameraForward.magnitude >= 0.01f)
        {
            rotation = Quaternion.LookRotation(CameraForward);
        }
        Move = rotation * new Vector3(x, 0, z);
        if (Move.magnitude >= 0.01f)
        {
            rotate = Quaternion.LookRotation(Move);
            _iswalk = true;
        }
        //if (Move == Vector3.zero) return;
        transform.rotation = rotate;
        anm.SetBool("Walk", _iswalk);
    }

    private void FixedUpdate()
    {
        rb.velocity = Move * PlayerSpeed * Time.deltaTime;
    }
}
