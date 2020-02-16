using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    [SerializeField] PathfindingGrid pathfindingGrid;

    [SerializeField] int width, height;

    GridGraph gridGraph;

    Dijkstra algorithm;

    [SerializeField] Transform target;

    [SerializeField] List<int> path;

    void Start()
    {
        InitializeObjects();

        PursueTarget();
    }

    void InitializeObjects()
    {
        SetupPathfindingGrid();

        SetUpGridGraph();

        algorithm = new Dijkstra();      
    }

    void SetupPathfindingGrid()
    {
        pathfindingGrid.Clear();
        pathfindingGrid.Create(width, height);
    }

    void SetUpGridGraph()
    {
        gridGraph = new GridGraph(width, height);
        gridGraph.SetInitialNode(GetInitialI(), GetInitialJ());
    }

    int GetInitialI()
    {
        return height / 2;
    }

    int GetInitialJ()
    {
        return width / 2;
    }

    void PursueTarget() {

        Vector3 deltaPosition = CalculateDeltaPosition();

        int targetI, targetJ;
        CalculateIJGridIndexes(deltaPosition, out targetI, out targetJ);

        gridGraph.SetDestinationNode(targetI, targetJ);

        path = algorithm.FindPath(gridGraph);

        StartCoroutine(MoveAlongPathThenRestart());
    }

    Vector3 CalculateDeltaPosition()
    {
        Vector3 actualDeltaPos = target.transform.position - transform.position;
        Vector3 insideBoundsDeltaPos = ClampDeltaPos(actualDeltaPos);
        return insideBoundsDeltaPos;
    }

    Vector3 ClampDeltaPos(Vector3 deltaPos)
    {
        Vector3 clamped = Vector3.zero;

        int minimum = (-width / 2);
        int minimumReallyInsideBounds = minimum + 1;

        int maximum = (width / 2);
        int maximumReallyInsideBounds = maximum - 1;

        clamped.x = Mathf.Clamp(deltaPos.x, minimumReallyInsideBounds, maximumReallyInsideBounds);
        clamped.y = Mathf.Clamp(deltaPos.y, minimumReallyInsideBounds, maximumReallyInsideBounds);

        return clamped;
    }

    //like a matrix, J grows from left to right, and I grows from top to bottom
    void CalculateIJGridIndexes(Vector3 deltaPosition, out int targetI, out int targetJ)
    {
        targetJ = GetInitialJ() + (int)deltaPosition.x;
        targetI = GetInitialI() - (int)deltaPosition.y;
    }

    IEnumerator MoveAlongPathThenRestart()
    {

        while ( ThereIsAPathToTheTarget() )
        {
            MoveToNextPoint();
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(1f);

        Start();
    }

    bool ThereIsAPathToTheTarget()
    {
        return path.Count > 0;
    }

    void MoveToNextPoint()
    {
        transform.position = pathfindingGrid.GetGridPoint(path[0]).transform.position;
        path.RemoveAt(0);
    }
}
