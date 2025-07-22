using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("プレイヤー"), SerializeField] Transform Player;
    [Header("パトロールチェックポイント"),SerializeField] Transform[] PatrolPoint;
    [Header("敵の数値")]
    [SerializeField] float moveSpeed = 2;
    [SerializeField] float viewDistance = 5f;
    [SerializeField] float viewAngle = 60f;

    int pointIndex;
    float distanceToPlayer;

    Transform targetPoint;
    Vector3 direction;
    Vector3 directionToPlayer;
    Quaternion rotate;

    private void Update()
    {
        Patrol();
        if (InSight())
        {
            Debug.Log("見つかった！");
        }
    }

    void Patrol()
    {
        targetPoint = PatrolPoint[pointIndex];
        direction = targetPoint.position - transform.position;
        rotate = Quaternion.LookRotation(direction);
        transform.rotation = rotate;
        transform.position += direction * moveSpeed * Time.deltaTime;
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

        if (distanceToPlayer > viewAngle / 2f) return false;

        Ray ray = new Ray(transform.position, directionToPlayer.normalized);
        if (Physics.Raycast(ray, out RaycastHit hit, viewDistance))
        {
            // プレイヤーに当たったら発見
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
}
