using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge
{
    int destination;
    float weight;

    public Edge(int destination, float weight)
    {
        this.destination = destination;
        this.weight = weight;
    }

    public int GetDestination()
    {
        return destination;
    }

    public float Getweight()
    {
        return weight;
    }
}

public class GridGraph
{
    public List<List<Edge>> nodes = new List<List<Edge>>();

    int width, height;

    int defaultweight = 1;

    int currentNode;

    public List<int> GetNeighbors(int v)
    {
        List<int> neighbors = new List<int>();

        foreach (Edge edge in nodes[v])
        {
            neighbors.Add( edge.GetDestination() );
        }

        return neighbors;
    }

    public int GetWeight(int u, int v)
    {
        return 1;
    }

    public int GetNodesQuantity()
    {
        return nodes.Count;
    }

    public GridGraph(int width, int heigth)
    {
        this.width = width;
        this.height = heigth;

        MountGraph();
    }

    void MountGraph()
    {
        InitializeWithEmptyLists();
        PopulateLists();
    }

    void InitializeWithEmptyLists()
    {
        //zero is a sentinel. Consider the matrix as starting at 1
        for (int i = 0; i <= width; i++)
        {
            for (int j = 0; j <= height; j++)
            {
                nodes.Add(new List<Edge>());
            }
        }
    }

    void PopulateLists()
    {
        for (int i = 1; i <= width; i++)
        {
            for (int j = 1; j <= height; j++)
            {
                ConfigureEdges(i, j);
            }
        }
    }

    void ConfigureEdges(int i, int j)
    {
        currentNode = CalculateCurrentNode(i, j);

        AddToGraph(GetLeft(currentNode), condition: JHasLeft(j));

        AddToGraph(GetRight(currentNode), condition: JHasRight(j));

        AddToGraph(GetUp(currentNode), condition: IHasUp(i));

        AddToGraph(GetDown(currentNode), condition: IHasDown(i));
    }

    public int CalculateCurrentNode(int i, int j)
    {
        return i * width + j;
    }

    void AddToGraph(int destination, bool condition)
    {
        if (condition)
        {
            nodes[currentNode].Add(new Edge(destination, defaultweight));
        }
    }

    int GetLeft(int node)
    {
        return node - 1;
    }

    int GetRight(int node)
    {
        return node + 1;
    }

    int GetUp(int node)
    {
        return node - width;
    }

    int GetDown(int node)
    {
        return node + width;
    }

    bool JHasLeft(int j)
    {
        return j > 1;
    }

    bool JHasRight(int j)
    {
        return j < width;
    }

    bool IHasUp(int i)
    {
        return i > 1;
    }

    bool IHasDown(int i)
    {
        return i < height;
    }

}