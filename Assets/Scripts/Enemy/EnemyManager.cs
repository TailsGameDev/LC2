using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] float intervalBetweenPathfinds;
    [SerializeField] Pathfinding pathfinding;

    [SerializeField] EnemyWalk enemyWalk;
    [SerializeField] EnemyAttacks enemyAttacks;
    [SerializeField] EnemyAnimator enemyAnimator;

    List<Vector3> path;

    Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(KeepPursuingTarget());
    }

    IEnumerator KeepPursuingTarget()
    {
        while (enabled)
        {
            path = pathfinding.FindPath(player);
            enemyWalk.PursueTarget(path);
            yield return new WaitForSeconds(intervalBetweenPathfinds);
        }
    }

    public void AttackTarget(Vector3 targetPosition)
    {
        enemyAttacks.AttackTarget(targetPosition);
        enemyAnimator.attack();
    }

}
