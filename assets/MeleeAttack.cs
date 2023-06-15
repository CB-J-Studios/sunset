using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Transform attackpoint;
    public float range = 0.5f;
    public LayerMask enemyLayers;
    
    private float KnockbackAmount = 15.0f; // i think we can make this scale off of strength or stats or something
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, range, enemyLayers);
        

        foreach (Collider2D enemy in hitEnemies)
        {
            KnockbackEffect knockback = new KnockbackEffect(KnockbackAmount, GetComponent<playerTouchMovement>().MovementAmount.normalized, enemy.gameObject);
            enemy.GetComponent<CharacterControl>().TakeDamage(gameObject.GetComponent<CharacterControl>().data.damage); // do damage based on stats

            IEffectable effectable = enemy.GetComponent<IEffectable>();
            if (effectable != null)
                effectable.ApplyEffect(knockback);

        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
            return;

        Gizmos.DrawWireSphere(attackpoint.position, range);
    }
}
