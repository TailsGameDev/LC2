using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDamageable : DamageableTemplate
{
    private void Start()
    {
        EnemyManager enemyManager = GetComponent<EnemyManager>();
        if (enemyManager == null)
        {
            Debug.LogError("[SkeletonDamageable] Should be attached to object with EnemyManagerScript", this);
        }
    }

    protected override void OnDied()
    {
        Destroy(transform.parent.gameObject);
    }
}
