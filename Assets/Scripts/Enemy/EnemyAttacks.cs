using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    [SerializeField]
    GameObject enemyDamager;

    [SerializeField]
    DamageableTemplate enemyDamageable;

    public void AttackTarget(Vector3 targetPosition)
    {
        EnemyDamager damager = Instantiate(enemyDamager, targetPosition, Quaternion.identity)
                                    .GetComponent<EnemyDamager>();
        damager.SetSpawner(enemyDamageable);
    }
}
