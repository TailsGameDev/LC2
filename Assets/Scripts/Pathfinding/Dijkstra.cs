using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra
{
    protected int infinity = 999999999;

    protected GridGraph gridGraph;

    protected float[] Distances;
    protected int[] Ancestors;
    bool[] Visited;

    public List<int> FindPath(GridGraph gridGraph, bool[] Visited)
    {
        Initialize(gridGraph, Visited);

        HandleObstructedDestination();

        if (DestinationStillObstructed())
        {
            return CouldNotFindAPath();
        }
        else
        {
            Ancestors = DijkstraLoop();

            return CalculatePath(Ancestors);
        }
    }

    void HandleObstructedDestination()
    {
        if (Visited[gridGraph.GetDestinationNode()])
        {
            gridGraph.TryToAjustDestination(Visited);
        }
    }

    bool DestinationStillObstructed()
    {
        return Visited[gridGraph.GetDestinationNode()];
    }

    List<int> CouldNotFindAPath()
    {
        return new List<int>();
    }

    void Initialize(GridGraph gridGraph, bool[] Visited)
    {
        this.gridGraph = gridGraph;
        this.Visited = Visited;

        int size = gridGraph.GetNodesQuantity();
        Distances = new float[size];
        Ancestors = new int[size];

        for (int vertex = 0; vertex < size; vertex++)
        {
            Distances[vertex] = infinity;
        }

        Distances[gridGraph.GetInitialNode()] = 0;
    }

    int[] DijkstraLoop()
    {
        while (ContainsFalse(Visited))
        {
            int nearestUnvisited = GetNearestUnvisitedVertex(Distances, Visited);
            // TODO: understand the cause of the exception then treat it propeperly
            try
            {
                Visited[nearestUnvisited] = true;
            } catch (Exception e)
            {
                Debug.LogError("[Dijkstra] Index "+nearestUnvisited+
                    " out of bounds at Dijkstra algorythm.\n" + e.Message);
                Visited[Visited.Length-1] = true;
            }
            foreach (int neighbor in gridGraph.GetNeighbors(nearestUnvisited))
            {
                UpdateDistanceAndAncestor(nearestUnvisited, neighbor);
            }
        }

        return Ancestors;
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

    int GetNearestUnvisitedVertex(float[] Distances, bool[] Visited)
    {
        float minValue = infinity;
        int minIndex = -1;
        for (int i = 0; i < Visited.Length; i++)
        {
            if (Distances[i] < minValue && !Visited[i])
            {
                minValue = Distances[i];
                minIndex = i;
            }
        }
        return minIndex;
    }

    void UpdateDistanceAndAncestor(int vertex, int neighbor)
    {
        if (!Visited[neighbor])
        {
            if (Distances[neighbor] > Distances[vertex] + GetDistance(vertex, neighbor))
            {
                Distances[neighbor] = Distances[vertex] + GetDistance(vertex, neighbor);
                Ancestors[neighbor] = vertex;
            }
        }
    }

    protected int GetDistance(int u, int v)
    {
        return gridGraph.GetWeight(u, v);
    }

    List<int> CalculatePath(int[] GetAncestor)
    {
        int initialNode = gridGraph.GetInitialNode();
        int destinationNode = gridGraph.GetDestinationNode();

        List<int> path = new List<int>();

        int node = destinationNode;
        while (node != initialNode)
        {
            path.Insert(0, GetAncestor[node]);
            node = GetAncestor[node];
        }

        return path;
    }
}