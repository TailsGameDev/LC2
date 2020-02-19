using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField] float speed;

    List<Vector3> path;

    float percentageOfPathConcluded;
    Vector3 initialPoint, nextPoint, direction;

    public void PursueTarget(List<Vector3> path)
    {
        StopAllCoroutines();
        this.path = path;
        StartCoroutine(MoveAlongPath());
    }

    IEnumerator MoveAlongPath()
    {
        while (ThereIsAPathToTheTarget())
        {
            StartWalk();

            yield return StartCoroutine(WalkLoop());

            EndWalk();
        }
    }

    bool ThereIsAPathToTheTarget()
    {
        return path.Count > 0;
    }

    void StartWalk()
    {
        percentageOfPathConcluded = 0;

        initialPoint = transform.position;
        nextPoint = path[0];
        direction = nextPoint - initialPoint;
    }

    IEnumerator WalkLoop()
    {
        while (percentageOfPathConcluded < 1)
        {
            percentageOfPathConcluded += Time.deltaTime * speed;
            transform.position = initialPoint + percentageOfPathConcluded * direction;
            yield return null;
        }
    }

    void EndWalk()
    {
        transform.position = nextPoint;
        path.RemoveAt(0);
    }

}
