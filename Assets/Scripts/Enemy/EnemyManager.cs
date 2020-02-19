using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] float intervalBetweenPathfinds;
    [SerializeField] Pathfinding pathfinding;

    [SerializeField] EnemyWalk enemyWalk;

    List<Vector3> path;

    void Start()
    {
        StartCoroutine(KeepPursuingTarget());
    }

    IEnumerator KeepPursuingTarget()
    {
        while (enabled)
        {
            path = pathfinding.FindPath(GameObject.FindWithTag("Player").transform);
            enemyWalk.PursueTarget(path);
            yield return new WaitForSeconds(intervalBetweenPathfinds);
        }
    }
    
}
