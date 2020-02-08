using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    [SerializeField] List<GameObject> objects;

    void InsertObject(GameObject obj)
    {
        objects.Add(obj);
    }

    void RemoveObject(GameObject obj)
    {
        objects.Remove(obj);
    }
}
