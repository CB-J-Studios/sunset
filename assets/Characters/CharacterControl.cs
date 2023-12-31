using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// character behavior from https://www.youtube.com/watch?v=e8GmfoaOB4Y&ab_channel=Brackeys
// data from scriptable object, usage here: https://www.youtube.com/watch?v=W5ECIJyoW80&ab_channel=Sirenix
public class CharacterControl : MonoBehaviour, IEffectable
{
    private List<IEffect> activeEffects = new List<IEffect>();

    public CharacterData data; // scriptable object, stores all data set somewhere else
    public int currentHealth { get; protected set; } // allows other objects to get, but only this object to modify current health

    // Start is called before the first frame update
    void Start()
    {
        if(data != null)
        {
            Awake();
        }
    }

    void Awake()
    {
        currentHealth = data.health; // set current health 
    }

    public virtual void TakeDamage (int damage)
    {
        currentHealth -= damage;
        Debug.Log(data.name + " takes " + damage + " damage.");

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    
    public virtual void Die()
    {
        // default dying
        // override with other classes derived from this
        if(gameObject.tag == "Enemy")
        {
            enemyManager.enemies.Remove(gameObject);

        }
        Destroy(gameObject);
        Debug.Log(data.name + "died"); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    // IEffectable stuff
    public void ApplyEffect(IEffect effect)
    {
        activeEffects.Add(effect);
        effect.Apply();
    }

    public void RemoveEffect(IEffect effect)
    {
        activeEffects.Remove(effect);
        effect.Remove();
    }

    public void RefreshEffect(IEffect effect)
    {
        activeEffects.Remove(effect);
        activeEffects.Add(effect);
        effect.Apply();
    }


    public void ClearEffects()
    {
        foreach (IEffect effect in activeEffects)
        {
            activeEffects.Remove(effect);
            effect.Remove(); // might need a cancel function to stop a coroutine
        }
    }

    public List<IEffect> GetActiveEffects()
    {
        return new List<IEffect>(activeEffects);
    }
}
