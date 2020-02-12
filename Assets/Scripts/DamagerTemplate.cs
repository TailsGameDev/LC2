using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamagerTemplate : MonoBehaviour
{

    [SerializeField] protected float damageAmount;
    [SerializeField] protected bool destroyItselfAfterHit;

    [SerializeField] protected DamageableTemplate spawnerOfThisDamager;
    [SerializeField] protected bool spawnerIsImmune;

    protected List<Type> immuneDamageableTypes = new List<Type>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageableTemplate damageable = other.GetComponent<DamageableTemplate>();

        if (damageable)
        {
            DecideIfIsImmuneThenDealDamage(damageable);
        }
    }

    void DecideIfIsImmuneThenDealDamage(DamageableTemplate damageable)
    {
        if (DamageableIsImmune(damageable))
        {
            return;
        }
        else
        {
            ExecuteDamageAlgorightm(damageable);
        }
    }

    bool DamageableIsImmune(DamageableTemplate damageable)
    {
        bool dodgeItsOwnAttack = damageable == spawnerOfThisDamager && spawnerIsImmune;
        bool damageableTypeIsImmune = immuneDamageableTypes.Contains(damageable.GetType());

        return dodgeItsOwnAttack || damageableTypeIsImmune;
    }

    void ExecuteDamageAlgorightm(DamageableTemplate damageable)
    {
        BeforeDoingDamage(damageable);

        damageable.Damage(this, damageAmount);

        AfterDoingDamage();

        if (destroyItselfAfterHit)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void BeforeDoingDamage(DamageableTemplate damageable)
    {

    }

    protected virtual void AfterDoingDamage()
    {

    }

}
