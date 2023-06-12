using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IEffectable
{
    void ApplyEffect(IEffect effect);
    void RemoveEffect(IEffect effect);
    void RefreshEffect(IEffect effect);
    void CancelEffect(IEffect effect);
    void ClearEffects();
}

public interface IEffect
{
    void Apply();
    void Remove();
}

public interface IStatusEffect : IEffect
{
    // Additional methods specific to status effects
    void Update();
}

public abstract class EffectBase : IEffect
{
    public abstract void Apply();
    public abstract void Remove();
}

public abstract class StatusEffectBase : EffectBase, IStatusEffect
{
    // Additional methods or properties specific to status effects
    public abstract void Update();
}
