using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float h = 10;
    void Update()
    {
        this.transform.position = new Vector3(target.transform.position.x, h, target.transform.position.z);
    }
}
