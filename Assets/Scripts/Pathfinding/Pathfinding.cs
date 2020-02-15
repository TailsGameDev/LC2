using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    Dijkstra dijkstra;

    [SerializeField] PathfindingGrid grid;

    GridGraph gridGraph;

    [SerializeField] List<int> path;

    [SerializeField] Transform target;

    void Start()
    {
        Dijkstra dijkstra = new Dijkstra( grid.GetWidth() * grid.GetHeight() / 2 );

        gridGraph = new GridGraph( grid.GetWidth(), grid.GetHeight() );

        Vector3 deltaPos = target.transform.position - transform.position;

        int x = Mathf.RoundToInt(deltaPos.x);
        int y = Mathf.RoundToInt(deltaPos.y);

        path = dijkstra.FindPath(gridGraph.CalculateCurrentNode(x,y), gridGraph);
    }

}
