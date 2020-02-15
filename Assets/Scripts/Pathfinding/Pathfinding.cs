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

        int i = grid.GetHeight() / 2;
        int j = grid.GetWidth() / 2;
        Dijkstra dijkstra = new Dijkstra( i*grid.GetWidth() +j );

        gridGraph = new GridGraph( grid.GetWidth(), grid.GetHeight() );

        Vector3 deltaPos = target.transform.position - transform.position;

        int targetJ = j + Mathf.RoundToInt(deltaPos.x);
        int targetI = i - Mathf.RoundToInt(deltaPos.y);

        path = dijkstra.FindPath(gridGraph.CalculateCurrentNode(targetI, targetJ), gridGraph);
        StartCoroutine(Go());
    }

    IEnumerator Go()
    {
        while (path.Count > 0)
        {
            transform.position = grid.GetGridPoint(path[0]).transform.position;
            yield return new WaitForSeconds(0.5f);
            path.RemoveAt(0);
        }
    }

}
