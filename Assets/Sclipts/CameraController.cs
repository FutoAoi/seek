using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("マウス感度"),SerializeField] public float MouseSensitivity = 100f;
    [SerializeField] float MinPitch = -45f;
    [SerializeField] float MaxPitch = 60f;
    
    [SerializeField] Transform CameraTransform;

    float pitch = 0f;
    float mouseX;
    float mouseY;
    Vector3 rightAxis;
        
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, MinPitch, MaxPitch);

        rightAxis = CameraTransform.right;
        CameraTransform.localRotation = Quaternion.AngleAxis(pitch, Vector3.right);
    }
}
