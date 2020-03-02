using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    [SerializeField] PathfindingGrid pathfindingGrid;

    [SerializeField] int width, height;

    GridGraph gridGraph;

    Dijkstra algorithm;

    List<int> path;

    private void Start()
    {
        algorithm = new Dijkstra();

        SetUpGridGraph();
    }

    private void SetUpGridGraph()
    {
        gridGraph = new GridGraph(width, height);
        gridGraph.SetInitialNode(GetInitialI(), GetInitialJ());
    }

    private int GetInitialI()
    {
        return height / 2;
    }

    private int GetInitialJ()
    {
        return width / 2;
    }

    public List<Vector3> FindPath(Transform target) {

        pathfindingGrid = ResetPathfindingGrid();

        gridGraph = SetDestinationInGridGraph(target);

        path = algorithm.FindPath(gridGraph, pathfindingGrid.GetIsGridPointObstructedArray());

        return IntToPositionList(path);
    }

    private PathfindingGrid ResetPathfindingGrid()
    {
        pathfindingGrid.Clear();
        pathfindingGrid.Create(width, height);
        return pathfindingGrid;
    }

    private GridGraph SetDestinationInGridGraph(Transform target)
    {
        Vector3 deltaPosition = CalculateDeltaPosition(target);

        int targetI, targetJ;
        CalculateTargetIJGridIndexes(deltaPosition, out targetI, out targetJ);

        gridGraph.SetDestinationNode(targetI, targetJ);

        return gridGraph;
    }

    private Vector3 CalculateDeltaPosition(Transform target)
    {
        Vector3 actualDeltaPos = target.transform.position - pathfindingGrid.transform.position;
        Vector3 insideBoundsDeltaPos = ClampDeltaPos(actualDeltaPos);
        return insideBoundsDeltaPos;
    }

    private Vector3 ClampDeltaPos(Vector3 deltaPos)
    {
        Vector3 clamped = Vector3.zero;

        clamped.x = Mathf.Clamp(deltaPos.x, (-width  / 2) +1, (width  / 2) -1);
        clamped.y = Mathf.Clamp(deltaPos.y, (-height / 2) +1, (height / 2) -1);

        return clamped;
    }

    //like a matrix, J grows from left to right, and I grows from top to bottom
    private void CalculateTargetIJGridIndexes(Vector3 deltaPosition, out int targetI, out int targetJ)
    {
        targetJ = GetInitialJ() + (int)deltaPosition.x;
        targetI = GetInitialI() - (int)deltaPosition.y;
    }

    private List<Vector3> IntToPositionList(List<int> intList)
    {
        List<Vector3> positionsList = new List<Vector3>();

        for (int i = 0; i < intList.Count; i++)
        {
            positionsList.Add(pathfindingGrid.GetGridPoint(intList[i]).transform.position);
        }

        return positionsList;
    }
}
