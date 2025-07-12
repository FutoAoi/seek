using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float PlayerSpeed = 10f;
    [SerializeField] float RotateSpeed = 50f;

    Vector3 Direction;
    float x;
    float z;

    private Transform tf;
    private Rigidbody rb;
    private Quaternion CameraRtation;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        CameraRtation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);
        Direction = CameraRtation * new Vector3(x, 0, z).normalized;
        
        if (Direction.magnitude > 0)
        {
            tf.rotation = Quaternion.LookRotation(Direction);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Direction * PlayerSpeed * Time.fixedDeltaTime);
    }
}
