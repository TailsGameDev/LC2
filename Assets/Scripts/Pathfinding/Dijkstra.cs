using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra
{
    protected int infinity = 999999999;

    public List<int> FindPath(GridGraph gridGraph)
    {
        int size = gridGraph.GetNodesQuantity();
        float[] D = new float[size];
        int[] A = new int[size];
        bool[] C = new bool[size];

        for (int v = 0; v < gridGraph.GetNodesQuantity(); v++)
        {
            D[v] = infinity;
            C[v] = false;
        }

        D[ gridGraph.GetInitialNode() ] = 0;

        while (ContainsFalse(C))
        {
            int u = ArgMin(D, C);
            C[u] = true;

            foreach (int v in gridGraph.GetNeighbors(u))
            {
                if (!C[v])
                {
                    if (D[v] > D[u] + gridGraph.GetWeight(u, v))
                    {
                        D[v] = D[u] + gridGraph.GetWeight(u, v);
                        A[v] = u;
                    }
                }
            }
        }

        return CalculatePath(gridGraph.GetInitialNode(), gridGraph.GetDestinationNode(), A);

    }

    protected bool ContainsFalse(bool[] boolArray)
    {
        for (int i = 0; i < boolArray.Length; i++)
        {
            if (!boolArray[i])
            {
                return true;
            }
        }
        return false;
    }


    int ArgMin(float[] D, bool[] C)
    {
        float minValue = infinity;
        int minIndex = -1;
        for (int i = 0; i < C.Length; i++)
        {
            if (D[i] < minValue && !C[i])
            {
                minValue = D[i];
                minIndex = i;
            }
        }
        return minIndex;
    }

    List<int> CalculatePath(int initialNode, int destinationNode, int[]A)
    {
        List<int> path = new List<int>();
        int node = destinationNode;
        while (node != initialNode)
        {
            path.Insert(0, A[node]);
            node = A[node];
        }
        return path;
    }
}