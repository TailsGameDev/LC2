using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingGrid : MonoBehaviour
{

    [SerializeField] GridPoint gridPointPrototype;

    GameObject gridPointsNode;
    GridPoint[] gridPoints;
    bool[] isGridPointObstructedArray;
    int width, height;

    bool showObstructedGridPointSquares = false;

    public void Create(int width, int height)
    {
        InitializeMemberVariables(width, height);

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                CreateGridPoint(i, j);
            }
        }
    }

    void InitializeMemberVariables(int width, int height)
    {
        this.width = width; this.height = height;

        gridPointsNode = new GameObject();
        gridPointsNode.transform.position = transform.position;

        gridPoints = new GridPoint[width * height];

        isGridPointObstructedArray = new bool[width * height];
    }

    void CreateGridPoint(int i, int j)
    {
        Vector3 pointPosition = CalculateGridPointPosition(i, j);

        GridPoint point = InstantiateGridPoint(pointPosition);

        isGridPointObstructedArray = DoPointConfigurations(point, i, j);

        ShowGridPointSquaresIfWanted(point, isGridPointObstructedArray);
    }

    Vector3 CalculateGridPointPosition(int i, int j)
    {
        Vector3 MiddleToTopLeftCornerOffset = new Vector3(-width / 2, height / 2, 0);
        Vector3 positionInGridOffset = new Vector3(j, -i, 0);
        Vector3 position = transform.position + positionInGridOffset + MiddleToTopLeftCornerOffset;
        return position;
    }

    GridPoint InstantiateGridPoint(Vector3 position)
    {
        Quaternion rotation = Quaternion.identity;

        GameObject p = Instantiate(gridPointPrototype.gameObject, position, rotation);

        return p.GetComponent<GridPoint>();
    }

    bool[] DoPointConfigurations(GridPoint point, int i, int j)
    {
        int index = i * width + j;

        gridPoints[index] = point;
        point.index = index;
        point.transform.parent = gridPointsNode.transform;

        isGridPointObstructedArray[index] = point.PointIsOverObstructedSurface();

        return isGridPointObstructedArray;
    }

    void ShowGridPointSquaresIfWanted(GridPoint point, bool[] isGridPointObstructedArray)
    {
        if (showObstructedGridPointSquares && isGridPointObstructedArray[point.index])
        {
            point.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public GridPoint GetGridPoint(int index)
    {
        return gridPoints[index];
    }

    public void Clear()
    {
        if (gridPoints != null)
        {
            foreach (GridPoint gp in gridPoints)
            {
                Destroy(gp.gameObject);
            }
        }
        if (gridPointsNode)
        {
            Destroy(gridPointsNode);
        }
    }

    public bool[] GetIsGridPointObstructedArray()
    {
        return isGridPointObstructedArray;
    }
}
