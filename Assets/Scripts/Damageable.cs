using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    [SerializeField] protected float maxHealthPoints;
    protected float healthPoints;

    public abstract void Damage(Damager damager, float damageAmount);

}
