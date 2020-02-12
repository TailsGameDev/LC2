using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableTemplate : MonoBehaviour
{
    [SerializeField] protected float maxHealthPoints;
    protected float healthPoints;

    public void Damage(DamagerTemplate damager, float damageAmount)
    {
        BeforeTakingDamage(damager);

        healthPoints -= damageAmount;

        AfterSubtractDamage(damager);

        if ( isDead() )
        {
            OnDied();
        }
    }


    protected virtual void BeforeTakingDamage(DamagerTemplate damager)
    {

    }

    protected virtual void AfterSubtractDamage(DamagerTemplate damager)
    {

    }

    protected virtual bool isDead()
    {
        return healthPoints < 0;
    }

    protected virtual void OnDied()
    {
        Destroy(gameObject);
    }
}
