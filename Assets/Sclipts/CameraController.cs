using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("追従するターゲット"),SerializeField] Transform target;        
    [Header("マウス感度"),SerializeField] float rotateSpeed = 3f;  

    float distance = 5f;     
    float height = 2f;       
    float currentX = 0f;    
    float currentY = 15f;   
    float minY = -20f;       
    float maxY = 80f;        
    float minDistance = 1f;
    float maxDistance = 7f;
    float scroll;

    Quaternion rotation;
    Vector3 targetPosition;
    private void Update()
    {
        scroll = Input.mouseScrollDelta.y;
        distance -= scroll * 0.5f;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        currentX += Input.GetAxis("Mouse X") * rotateSpeed;
        currentY -= Input.GetAxis("Mouse Y") * rotateSpeed;
        currentY = Mathf.Clamp(currentY, minY, maxY);
    }
    void LateUpdate()
    {
        if (target == null) return;

        rotation = Quaternion.Euler(currentY, currentX, 0);
        targetPosition = target.position + Vector3.up * height - rotation * Vector3.forward * distance;
        transform.position = targetPosition;
        transform.LookAt(target.position + Vector3.up * height);
    }
}
