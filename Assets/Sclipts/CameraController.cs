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
    RaycastHit hit;
    Vector3 lookTarget;
    Vector3 desiredCameraPos;
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
        lookTarget = target.position + Vector3.up * height;
        desiredCameraPos = lookTarget - rotation * Vector3.forward * distance;
        if (Physics.Raycast(lookTarget, desiredCameraPos - lookTarget, out hit, distance))
        {
            transform.position = hit.point - (desiredCameraPos - lookTarget).normalized * 0.1f;
        }
        else
        {
            transform.position = desiredCameraPos;
        }

        transform.LookAt(lookTarget);
    }
}
