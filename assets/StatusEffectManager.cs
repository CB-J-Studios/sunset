using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// IGNORE ALL THIS SHIT
/// </summary>
public class StatusEffectManager : MonoBehaviour
{
    private Dictionary<IEffect, Coroutine> effectCoroutines;

    private void Awake()
    {
        effectCoroutines = new Dictionary<IEffect, Coroutine>();
    }

    private Dictionary<IEffect, Coroutine> runningCoroutines = new Dictionary<IEffect, Coroutine>();

    public void ApplyEffect(IEffect effect)
    {
        if (runningCoroutines.ContainsKey(effect))
        {
            // Remove the existing effect before applying the new one
            RemoveEffect(effect);
        }

        // Start the effect coroutine
        Coroutine coroutine = StartCoroutine(RunEffect(effect));
        runningCoroutines.Add(effect, coroutine);
    }

    public void RemoveEffect(IEffect effect)
    {
        if (runningCoroutines.TryGetValue(effect, out Coroutine coroutine))
        {
            StopCoroutine(coroutine);
            runningCoroutines.Remove(effect);
        }
    }

    private IEnumerator RunEffect(IEffect effect)
    {
        // Apply the effect
        effect.Apply();

        // Wait for the effect to finish
        while (!effect.IsInstant)
        {
            effect.Update();
            yield return null;
        }

        // Remove the effect
        effect.Remove();
    }
}
