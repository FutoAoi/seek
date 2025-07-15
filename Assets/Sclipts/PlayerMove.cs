using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float PlayerSpeed = 10f;
    [SerializeField] float RotateSpeed = 10f;

    [SerializeField] Transform cameraRoot;

    float x;
    float z;
    Quaternion rotation;
    Quaternion rotate;
    Vector3 Move;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Mover();
    }

    private void Mover()
    {
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
        }
        if (Move == Vector3.zero) return;
        transform.rotation = rotate;
    }

    private void FixedUpdate()
    {
        rb.velocity = Move * PlayerSpeed * Time.deltaTime;
    }
}
