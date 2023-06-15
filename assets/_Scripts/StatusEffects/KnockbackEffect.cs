using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// note: since this is instant, you should set 'isinstant' to true so it doesn't start a coroutine
public class KnockbackEffect : StatusEffectBase
{
    private float knockbackAmount;
    private Vector2 knockbackDirection;

    private Rigidbody2D targetBody;
    public UnityEvent OnBegin, OnDone;
    private Coroutine effectCoroutine;

    private float delay = 0.25f;
    
    public KnockbackEffect(float amount, Vector2 direction, GameObject target)
    {
        IsInstant = true;
        knockbackAmount = amount;
        knockbackDirection = direction;
        Target = target;
    }

    public override void Apply()
    {
        ApplyEffect(Target);
        if (!IsInstant)
        {
            effectCoroutine = Target.GetComponent<MonoBehaviour>().StartCoroutine(Reset());
        }
    }

    public override void ApplyEffect(GameObject target)
    {
        targetBody = target.GetComponent<Rigidbody2D>();
        Debug.Log("punch");
        targetBody.AddForce(knockbackDirection * knockbackAmount, ForceMode2D.Impulse);
        // Start a reset coroutine on the target 
        effectCoroutine = target.GetComponent<MonoBehaviour>().StartCoroutine(Reset());
    }

    // COROUTINE WHERE ALL THE MAGIC LIES
    private IEnumerator Reset()
    {
        Target.GetComponent<EnemyControl>().enabled = false;
        Debug.Log("Starting reset");
        yield return new WaitForSeconds(delay);
        targetBody.velocity = Vector2.zero;
        // Invoke the OnDone event
        Target.GetComponent<EnemyControl>().enabled = true;

        Remove();
    }

    public override void RemoveEffect(GameObject target)
    {

    }

    public override void Update()
    {

    }

    public override void Remove()
    {
        if (effectCoroutine != null)
        {
            Target.GetComponent<MonoBehaviour>().StopCoroutine(effectCoroutine);
            effectCoroutine = null;
        }
        RemoveEffect(Target);
    }

    // Rest of the class implementation
}
