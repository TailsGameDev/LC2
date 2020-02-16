using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingGrid : MonoBehaviour
{

    [SerializeField] GridPoint gridPointPrototype;

    GameObject gridGameObject;
    GridPoint[] gridPoints;

    public void Create(int width, int height)
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

    public void Reposition(Vector3 newPosition)
    {
        gridGameObject.transform.position = newPosition;
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
        if (gridGameObject)
        {
            Destroy(gridGameObject);
        }
    }
}
