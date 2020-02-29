using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDamageable : DamageableTemplate
{
    protected override void OnDied()
    {
        Destroy(transform.parent.gameObject);
    }
}
