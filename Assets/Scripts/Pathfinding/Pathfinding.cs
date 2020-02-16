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
        Vector3 clampedDeltaPos = ClampDeltaPos(deltaPos);

        int targetJ = GetInitialJ() + (int)clampedDeltaPos.x;//Mathf.RoundToInt(deltaPos.x);
        int targetI = GetInitialI() - (int)clampedDeltaPos.y;//Mathf.RoundToInt(deltaPos.y);

        gridGraph.SetDestinationNode(targetI, targetJ);

        path = dijkstra.FindPath(gridGraph);

        StartCoroutine(Go());
    }

    IEnumerator Go()
    {
        if (path.Count == 0)
        {
            yield return new WaitForSeconds(1f);
        }

        while (path.Count > 0)
        {
            transform.position = pathfindingGrid.GetGridPoint(path[0]).transform.position;
            yield return new WaitForSeconds(0.5f);
            path.RemoveAt(0);
        }

        Start();
    }

    Vector3 ClampDeltaPos(Vector3 deltaPos)
    {
        float clampedX = deltaPos.x;
        if (deltaPos.x > width / 2)
        {
            clampedX = width / 2 -1; //-1 and +1 to avoid out of bounds bugs
        }
        else if (deltaPos.x < -width / 2)
        {
            clampedX = -width / 2 +1;
        }

        float clampedY = deltaPos.y;
        if (deltaPos.y > height / 2)
        {
            clampedY = height / 2 -1;
        }
        else if (deltaPos.y < -height / 2)
        {
            clampedY = -height / 2 +1;
        }

        return new Vector3(clampedX, clampedY, 0);
    }

}
