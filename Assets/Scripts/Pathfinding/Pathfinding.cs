using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    Dijkstra dijkstra;

    [SerializeField] PathfindingGrid pathfindingGrid;

    GridGraph gridGraph;

    [SerializeField] List<int> path;

    [SerializeField] Transform target;

    [SerializeField] int width, height;


    void Start()
    {
        GridGraph gridGraph = Prepare();

        FindPathAndGo(gridGraph);
    }

    GridGraph Prepare()
    {
        pathfindingGrid.Clear();
        pathfindingGrid.Create(width, height);

        gridGraph = new GridGraph(width, height);
        gridGraph.SetInitialNode(GetInitialI(), GetInitialJ());

        dijkstra = new Dijkstra();

        return gridGraph;       
    }

    int GetInitialI()
    {
        return height / 2;
    }

    int GetInitialJ()
    {
        return width / 2;
    }

    void FindPathAndGo(GridGraph gridGraph) {
        // TODO: deal with out of range target

        Vector3 deltaPos = target.transform.position - transform.position;

        int targetJ = GetInitialI() + Mathf.RoundToInt(deltaPos.x);
        int targetI = GetInitialJ() - Mathf.RoundToInt(deltaPos.y);

        gridGraph.SetDestinationNode(gridGraph.CalculateNodeIndex(targetI, targetJ));

        path = dijkstra.FindPath(gridGraph);

        StartCoroutine(Go());
    }

    IEnumerator Go()
    {
        while (path.Count > 0)
        {
            transform.position = pathfindingGrid.GetGridPoint(path[0]).transform.position;
            yield return new WaitForSeconds(0.5f);
            path.RemoveAt(0);
        }
    }


}
