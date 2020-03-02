using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVulnerableMeleeArea : MonoBehaviour
{
    [SerializeField] Transform player;

    private void OnTriggerEnter2D(Collider2D col)
    {
        EnemyManager enemyManager = col.GetComponent<EnemyManager>();
        Debug.LogError("called event");
        if (enemyManager != null)
        {
            enemyManager.AttackTarget(player.position);
            Debug.LogError("called attack");
        }
    }
}
