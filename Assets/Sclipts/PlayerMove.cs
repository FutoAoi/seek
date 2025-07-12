using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float PlayerSpeed = 10f;
    [SerializeField] float RotateSpeed = 50f;

    Vector3 Direction;
    float x;
    float z;


    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Direction = new Vector3(x, 0, z).normalized;
        
        if (Direction.magnitude > 0)
        {
            //var angle = 
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Direction * PlayerSpeed * Time.fixedDeltaTime);
    }
}
