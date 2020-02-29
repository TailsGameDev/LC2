using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPoint : MonoBehaviour
{
    public int index;
    [SerializeField] Collider2D col;

    public bool PointIsOverObstructedSurface()
    {
        Collider2D[] overlappedColliders = new Collider2D[3];
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(LayerMask.GetMask("Obstacles"));
        int numberOfCollidersIntersect = col.OverlapCollider(contactFilter, overlappedColliders);

        return numberOfCollidersIntersect > 0;
    }
}
