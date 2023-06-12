using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Transform attackpoint;
    public float range = 0.5f;
    public LayerMask enemyLayers;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, range, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<CharacterControl>().TakeDamage(gameObject.GetComponent<CharacterControl>().data.damage); // do damage based on stats
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
            return;

        Gizmos.DrawWireSphere(attackpoint.position, range);
    }
}
