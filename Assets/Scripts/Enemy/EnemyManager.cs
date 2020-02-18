using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] int pathfindingWidth, pathfindingHeight;
    Pathfinding pathfinding;

    List<Vector3> path;

    void Start()
    {
        pathfinding = new Pathfinding(gameObject, pathfindingWidth, pathfindingHeight);
        PursueTarget();
    }

    void PursueTarget()
    {
        path = pathfinding.FindPath(GameObject.FindWithTag("Player").GetComponent<Transform>());
        StartCoroutine(MoveAlongPathThenRestart());
    }

    IEnumerator MoveAlongPathThenRestart()
    {

        while (ThereIsAPathToTheTarget())
        {
            MoveToNextPoint();
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(1f);

        PursueTarget();
    }

    bool ThereIsAPathToTheTarget()
    {
        return path.Count > 0;
    }

    void MoveToNextPoint()
    {
        transform.position = path[0];
        path.RemoveAt(0);
    }
}
