using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPoint : MonoBehaviour
{
    [SerializeField] Collider2D col;

    public bool PointIsOverWalkableSurface()
    {
        Collider2D[] overlappedColliders = new Collider2D[3];
        ContactFilter2D contactFilter = new ContactFilter2D();
        int numberOfCollidersIntersect = col.OverlapCollider(contactFilter.NoFilter(), overlappedColliders);

        return numberOfCollidersIntersect == 0;
    }
}
