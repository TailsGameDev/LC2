using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingGrid : MonoBehaviour
{

    [SerializeField] GridPoint gridPointPrototype;


    [SerializeField] int width, height;

    GameObject gridGameObject;
    GridPoint[] gridPoints;

    void Awake()
    {
        gridGameObject = new GameObject();
        gridGameObject.transform.position = transform.position;

        gridPoints = new GridPoint[width * height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3 offset = new Vector3(width/2, height/2, 0);
                Vector3 positionInArray = new Vector3(j, height-i, 0);
                Vector3 position = transform.position + positionInArray - offset;
                Quaternion rotation = Quaternion.identity;
                gridPoints[i*width + j] = Instantiate(gridPointPrototype.gameObject, position, rotation)
                                    .GetComponent<GridPoint>();
                gridPoints[i * width + j].id = i * width + j;
                gridPoints[i * width + j].transform.parent = gridGameObject.transform;
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
    
    public GridPoint GetGridPoint(int index)
    {
        return gridPoints[index];
    }
}
