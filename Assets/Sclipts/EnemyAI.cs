using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("プレイヤー"), SerializeField] Transform Player;
    [Header("パトロールチェックポイント"), SerializeField] Transform[] PatrolPoint;
    [Header("敵の数値")]
    [SerializeField] float moveSpeed = 2;
    [SerializeField] float viewDistance = 10f;
    [SerializeField] float viewAngle = 60f;

    int pointIndex;
    float distanceToPlayer;

    Transform targetPoint;
    Vector3 direction;
    Vector3 directionToPlayer;
    Quaternion rotate;

    private void Update()
    {
        if (InSight())
        {
            Debug.Log("見つかった！");
        }
        else
        {
            Patrol();
        }
    }

    private void LateUpdate()
    {
        DrawViewCone();
    }

    void Patrol()
    {
        targetPoint = PatrolPoint[pointIndex];
        direction = targetPoint.position - transform.position;
        rotate = Quaternion.LookRotation(direction);
        transform.rotation = rotate;
        transform.position += direction.normalized * moveSpeed * Time.deltaTime;
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.2f)
        {
            pointIndex = (pointIndex + 1) % PatrolPoint.Length;
        }
    }

    bool InSight()
    {
        directionToPlayer = Player.position - transform.position;
        distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer > viewDistance) return false;

        float angle = Vector3.Angle(transform.forward, directionToPlayer);

        if (angle > viewAngle / 2) return false;
        Vector3 eyePosition = transform.position + Vector3.up * 1.5f;
        Ray ray = new Ray(eyePosition, directionToPlayer.normalized);
        if (Physics.Raycast(ray, out RaycastHit hit, viewDistance))
        {
            if (hit.transform == Player)
            {
                return true;
            }
        }

        return false;
    }

    void OnDrawGizmosSelected()
    {
        if (Player == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewDistance);

        Vector3 left = Quaternion.Euler(0, -viewAngle / 2f, 0) * transform.forward;
        Vector3 right = Quaternion.Euler(0, viewAngle / 2f, 0) * transform.forward;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, left * viewDistance);
        Gizmos.DrawRay(transform.position, right * viewDistance);
    }

    void DrawViewCone()
    {
        if (Player == null) return;

        // 敵の現在の位置
        Vector3 pos = transform.position;

        // 扇の左端の方向
        Vector3 leftDir = Quaternion.Euler(0, -viewAngle / 2f, 0) * transform.forward;
        // 扇の右端の方向
        Vector3 rightDir = Quaternion.Euler(0, viewAngle / 2f, 0) * transform.forward;

        // 黄色の線で視野を描く
        Debug.DrawLine(pos, pos + leftDir * viewDistance, Color.yellow);
        Debug.DrawLine(pos, pos + rightDir * viewDistance, Color.yellow);
    }
}
