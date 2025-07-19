using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("プレイヤー"), SerializeField] Transform Player;
    [Header("パトロールチェックポイント"),SerializeField] Transform[] PatrolPoint;
    [Header("敵の数値")]
    [SerializeField] float moveSpeed;
    [SerializeField] float viewDistance = 5f;
    [SerializeField] float viewAngle = 60f;

    int pointIndex;
    float distanceToPlayer;

    Transform targetPoint;
    Vector3 direction;
    Vector3 thisTransform;
    Vector3 directionToPlayer;
    void Patrol()
    {
        thisTransform = transform.position;
        targetPoint = PatrolPoint[pointIndex];
        direction = targetPoint.position - thisTransform;
        thisTransform += direction * moveSpeed * Time.deltaTime;
        if (Vector3.Distance(thisTransform, targetPoint.position) < 0.2f)
        {
            pointIndex = (pointIndex + 1) % PatrolPoint.Length;
        }
    }

    bool InSight()
    {
        directionToPlayer = Player.position - thisTransform;
        distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer < viewDistance) return false;

        float angle = Vector3.Angle(transform.forward, directionToPlayer);

        if (distanceToPlayer < viewAngle) return false;

        Ray ray = new Ray();
        return false;
    }
}
