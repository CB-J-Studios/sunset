using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnEffect : StatusEffectBase
{
    private float damagePerTick;
    private float tickInterval;

    public BurnEffect(float damagePerTick, float tickInterval)
    {
        this.damagePerTick = damagePerTick;
        this.tickInterval = tickInterval;
    }
    


    private void ApplyDamage()
    {
        // Apply damage to the affected target
        // Use the damagePerTick parameter to calculate and apply the damage
    }

    public override void Remove()
    {
        // Implementation for removing the damage over time effect
    }

    public override void Update()
    {
        // Implementation for updating the damage over time effect
    }

    public override void Apply()
    {
        
    }

    public override void ApplyEffect(GameObject target)
    {
        throw new System.NotImplementedException();
    }

    public override void RemoveEffect(GameObject target)
    {
        throw new System.NotImplementedException();
    }
}

