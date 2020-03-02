using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : DamagerTemplate
{
    public void SetSpawner(DamageableTemplate spawner)
    {
        this.spawnerOfThisDamager = spawner;
    }
}
