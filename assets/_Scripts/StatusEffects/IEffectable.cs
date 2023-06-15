using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is what you work with when you are calling effects
public interface IEffectable
{
    List<IEffect> GetActiveEffects();
    void ApplyEffect(IEffect effect);
    void RemoveEffect(IEffect effect);
    void RefreshEffect(IEffect effect);
    // void CancelEffect(IEffect effect); // don't think we need this yet, maybe for stopping coroutines
    void ClearEffects();
}


// this is what you work with when you are creating effects
public interface IEffect
{
    GameObject Target { get; set; }
    bool IsInstant { get; } // tells whether it's an instant effect or not; used for coroutines
    void Apply(); // is called with ApplyEffect 
    void Remove();
    void Update();
}

// this adds a layer of abstraction for handling effect-specific events, such as stacking, effect interactions, etc
public interface IStatusEffect : IEffect
{
    void ApplyEffect(GameObject target);
    void RemoveEffect(GameObject target);
}

// class that all effects are based off of, can probably use for things that aren't necessarily status effects
public abstract class EffectBase : IEffect
{
    public GameObject Target { get; set; }
    public bool IsInstant { get; protected set; } = false; // by default it's not instant, had this for handling coroutines, not sure if i need this
    
    // functions from IEffect interface that get called
    public abstract void Apply();  
    public abstract void Remove();
    public abstract void Update();
}

// provides functionality for status effects specifically
public abstract class StatusEffectBase : EffectBase, IStatusEffect
{
    public abstract void ApplyEffect(GameObject target);
    public abstract void RemoveEffect(GameObject target);
}
