using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField, Min(0.1f)]
    private float damageRadius = 3f;

    [SerializeField, Min(1)]
    private int damage = 3;

    [SerializeField]
    private LayerMask enemyLayer;

    [Header("Lifetime")]
    [SerializeField, Min(0.1f)]
    private float lifetime = 0.67f;

    void Start()
    {
        DamageEnemiesInRange();
        Destroy(gameObject, lifetime);
    }

    void DamageEnemiesInRange()
    {
        Collider2D[] hitColliders =
            Physics2D.OverlapCircleAll(
                transform.position,
                damageRadius,
                enemyLayer
            );

        HashSet<EnemyHealth> damagedEnemies =
            new HashSet<EnemyHealth>();

        foreach (Collider2D hitCollider in hitColliders)
        {
            EnemyHealth enemyHealth =
                hitCollider.GetComponentInParent<EnemyHealth>();

            if (enemyHealth == null ||
                !damagedEnemies.Add(enemyHealth))
            {
                continue;
            }

            enemyHealth.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, damageRadius);
    }
}