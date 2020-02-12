using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damager : MonoBehaviour
{

    [SerializeField] protected float damageAmount;
    [SerializeField] protected bool destroyItselfAfterHit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Damageable damageable = other.GetComponent<Damageable>();

        if (damageable)
        {
            damageable.Damage(this, damageAmount);

            OnDoDamage(damageable);

            if (destroyItselfAfterHit)
            {
                Destroy(gameObject);
            }
        }
    }

    protected abstract void OnDoDamage(Damageable damageable);

}
