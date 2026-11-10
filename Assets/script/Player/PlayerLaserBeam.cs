using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserBeam : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField, Min(1)]
    private int damage = 1;

    [SerializeField, Min(0.01f)]
    private float damageInterval = 0.25f;

    [SerializeField]
    private LayerMask enemyLayer;

    [Header("Beam Area")]
    [SerializeField, Min(0.1f)]
    private float beamWidth = 0.9f;

    [SerializeField, Min(0.1f)]
    private float beamLength = 17.25f;

    [Header("Duration")]
    [SerializeField, Min(0.1f)]
    private float duration = 3f;

    private float nextDamageTime;
    private float endTime;

    void Start()
    {
        endTime = Time.time + duration;

        DamageEnemiesInBeam();
        nextDamageTime = Time.time + damageInterval;
    }

    void Update()
    {
        if (Time.time >= endTime)
        {
            Destroy(gameObject);
            return;
        }

        if (Time.time < nextDamageTime)
        {
            return;
        }

        DamageEnemiesInBeam();
        nextDamageTime = Time.time + damageInterval;
    }

    void DamageEnemiesInBeam()
    {
        Vector2 beamCenter =
            (Vector2)transform.position +
            (Vector2)transform.up * (beamLength * 0.5f);

        Collider2D[] hitColliders =
            Physics2D.OverlapBoxAll(
                beamCenter,
                new Vector2(beamWidth, beamLength),
                transform.eulerAngles.z,
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
        Vector2 beamCenter =
            (Vector2)transform.position +
            (Vector2)transform.up * (beamLength * 0.5f);

        Gizmos.color = Color.magenta;

        Gizmos.DrawWireCube(
            beamCenter,
            new Vector3(beamWidth, beamLength, 0f)
        );
    }
}