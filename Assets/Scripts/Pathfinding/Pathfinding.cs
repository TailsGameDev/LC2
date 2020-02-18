using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    PathfindingGrid pathfindingGrid;

    int width, height;

    GridGraph gridGraph;

    Dijkstra algorithm;

    List<int> path;

    public Pathfinding(GameObject owner, int width, int height)
    {
        this.width = width; this.height = height;

        pathfindingGrid = owner.AddComponent<PathfindingGrid>();

        SetUpGridGraph();

        algorithm = new Dijkstra();
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

    public List<Vector3> FindPath(Transform target) {

        ResetPathFindingGrid();

        Vector3 deltaPosition = CalculateDeltaPosition(target);

        int targetI, targetJ;
        CalculateIJGridIndexes(deltaPosition, out targetI, out targetJ);

        gridGraph.SetDestinationNode(targetI, targetJ);

        List<int> path = algorithm.FindPath(gridGraph);

        return IntToPositionList(path);
    }

    void ResetPathFindingGrid()
    {
        pathfindingGrid.Clear();
        pathfindingGrid.Create(width, height);
    }

    Vector3 CalculateDeltaPosition(Transform target)
    {
        Vector3 actualDeltaPos = target.transform.position - pathfindingGrid.transform.position;
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

    List<Vector3> IntToPositionList(List<int> intList)
    {
        List<Vector3> positionsList = new List<Vector3>();

        for (int i = 0; i < intList.Count; i++)
        {
            positionsList.Add(pathfindingGrid.GetGridPoint(intList[i]).transform.position);
        }

        return positionsList;
    }
}
