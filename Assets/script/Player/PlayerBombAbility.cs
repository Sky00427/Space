using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBombAbility : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private PlayerLevel playerLevel;

    [SerializeField]
    private InputActionReference bombAction;

    [Header("Unlock")]
    [SerializeField, Min(1)]
    private int unlockLevel = 5;

    [Header("Bomb")]
    [SerializeField, Min(0.1f)]
    private float damageRadius = 3f;

    [SerializeField, Min(1)]
    private int damage = 3;

    [SerializeField, Min(0f)]
    private float cooldown = 5f;

    [SerializeField]
    private LayerMask enemyLayer;

    private float nextAvailableTime;

    public bool IsUnlocked =>
        playerLevel.CurrentLevel >= unlockLevel;

    public float CooldownRemaining =>
        Mathf.Max(
            0f,
            nextAvailableTime - Time.time
        );

    void OnEnable()
    {
        bombAction.action.performed +=
            OnBombPerformed;

        bombAction.action.Enable();
    }

    void OnDisable()
    {
        bombAction.action.performed -=
            OnBombPerformed;

        bombAction.action.Disable();
    }

    void OnBombPerformed(
        InputAction.CallbackContext context
    )
    {
        TryUseBomb();
    }

    public void TryUseBomb()
    {
        if (!IsUnlocked)
        {
            Debug.Log(
                $"Bomb 將在 Lv.{unlockLevel} 解鎖。"
            );

            return;
        }

        if (Time.time < nextAvailableTime)
            return;

        nextAvailableTime =
            Time.time + cooldown;

        DamageEnemiesInRange();
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

        foreach (
            Collider2D hitCollider
            in hitColliders
        )
        {
            EnemyHealth enemyHealth =
                hitCollider.GetComponentInParent<
                    EnemyHealth
                >();

            if (
                enemyHealth == null ||
                damagedEnemies.Contains(enemyHealth)
            )
            {
                continue;
            }

            damagedEnemies.Add(enemyHealth);
            enemyHealth.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(
            transform.position,
            damageRadius
        );
    }
}