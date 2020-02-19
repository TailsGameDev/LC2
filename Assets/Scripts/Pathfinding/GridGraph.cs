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
    protected List<List<Edge>> nodes = new List<List<Edge>>();

    protected int width, height;

    protected int defaultweight = 1;

    protected int initialNode, destinationNode;

    protected int currentNode;


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
        return defaultweight;
    }

    public int GetNodesQuantity()
    {
        return nodes.Count;
    }

    protected GridGraph()
    {

    }

    public GridGraph(int width, int heigth)
    {
        this.width = width;
        this.height = heigth;

        MountGraph();
    }

    protected void MountGraph()
    {
        InitializeWithEmptyLists();
        PopulateLists();
    }

    protected void InitializeWithEmptyLists()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                nodes.Add(new List<Edge>());
            }
        }
    }

    protected void PopulateLists()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                ConfigureEdges(i, j);
            }
        }
    }

    protected void ConfigureEdges(int i, int j)
    {
        currentNode = CalculateNodeIndex(i, j);

        AddEdgeToCurrentNode(GetLeft(currentNode), condition: JHasLeft(j));

        AddEdgeToCurrentNode(GetRight(currentNode), condition: JHasRight(j));

        AddEdgeToCurrentNode(GetTop(currentNode), condition: IHasTop(i));

        AddEdgeToCurrentNode(GetBottom(currentNode), condition: IHasBottom(i));
    }

    public int CalculateNodeIndex(int i, int j)
    {
        return i * width + j;
    }

    protected void AddEdgeToCurrentNode(int destination, bool condition)
    {
        if (condition)
        {
            nodes[currentNode].Add(new Edge(destination, defaultweight));
        }
    }

    protected int GetLeft(int node)
    {
        return node - 1;
    }

    protected int GetRight(int node)
    {
        return node + 1;
    }

    protected int GetTop(int node)
    {
        return node - width;
    }

    protected int GetBottom(int node)
    {
        return node + width;
    }

    protected bool JHasLeft(int j)
    {
        return j > 0;
    }

    protected bool JHasRight(int j)
    {
        return j < width-1;
    }

    protected bool IHasTop(int i)
    {
        return i > 0;
    }

    protected bool IHasBottom(int i)
    {
        return i < height-1;
    }

    public void TryToAjustDestination(bool[] Visited)
    {
        int node = GetDestinationNode();

        int i, j;
        GetIJ(node, out i, out j);

        TryAjust(GetLeft(node), JHasLeft(j), Visited);
        TryAjust(GetRight(node), JHasRight(j), Visited);
        TryAjust(GetTop(node), IHasTop(i), Visited);
        TryAjust(GetBottom(node), IHasBottom(i), Visited);
    }

    protected bool TryAjust(int newNode, bool hasNeighbor, bool[] Visited)
    {
        if (hasNeighbor && !Visited[newNode])
        {
            destinationNode = newNode;
            return true;
        }
        return false;
    }

    protected void GetIJ(int node, out int i, out int j)
    {
        i = node / width;
        j = node - (i * width);
    }

    public int GetInitialNode()
    {
        return initialNode;
    }

    public void SetInitialNode(int i, int j)
    {
        this.initialNode = CalculateNodeIndex(i,j);
    }

    public int GetDestinationNode()
    {
        return destinationNode;
    }

    public void SetDestinationNode(int i, int j)
    {
        this.destinationNode = CalculateNodeIndex(i,j);
    }

}