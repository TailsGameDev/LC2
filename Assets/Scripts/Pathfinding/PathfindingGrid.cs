using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingGrid : MonoBehaviour
{
    [SerializeField] GridPoint gridPointPrototype;

    [SerializeField] int width, height;
    GridPoint[] gridPoints;

    void Awake()
    {
        gridPoints = new GridPoint[(width+1) * (height+1)];

        for (int i = 1; i <= width; i++)
        {
            for (int j = 1; j <= height; j++)
            {
                Vector3 offset = new Vector3(width/2, height/2, 0);
                Vector3 positionInArray = new Vector3(i, j, 0);
                Vector3 position = transform.position + positionInArray - offset;
                Quaternion rotation = Quaternion.identity;
                gridPoints[i*width + j] = Instantiate(gridPointPrototype.gameObject, position, rotation)
                                    .GetComponent<GridPoint>();
            }
        }
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }
}
