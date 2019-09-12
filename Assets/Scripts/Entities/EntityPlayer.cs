using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPlayer : Entity
{
    public void OnDeath()
    {
        GameManager.OnReset();
    }

    // Resets game level on death
    public override void DamageEntity(float damagePoints)
    {
        base.DamageEntity(damagePoints);
        if(health <= 0)
        {
            OnDeath();
        }
    }
}
