using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageable : DamageableTemplate
{
    [SerializeField]
    GameObject objToSpawnOnDeath, objToDestroyOnDeath;

    [SerializeField]
    PlayerAnimationManager playerAnimationManager;

    protected override void OnDied()
    {
        Instantiate(objToSpawnOnDeath, transform.position, Quaternion.identity);
        Destroy(objToDestroyOnDeath);
    }

    protected override void BeforeTakingDamage(DamagerTemplate damager)
    {
        playerAnimationManager.InformDamaged();
    }
}
