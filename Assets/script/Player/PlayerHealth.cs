using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerInvincibility playerInvincibility;
    [Header("Health")]
    public int maxHealth = 3;

    [SerializeField] private int currentHealth;


    private bool isDead;

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;

    public Action OnHealthChanged;

    void Start()
    {
        ResetHealth();
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        if (isDead || damage <= 0 || playerInvincibility.IsInvincible) return;
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        Debug.Log($"Player Health: {currentHealth}/{maxHealth}");
        OnHealthChanged?.Invoke();

        if (currentHealth <= 0)
        {
            Die();
            return;
        }

        playerInvincibility.Activate();
    }

    void Die()
    {
        isDead = true;
        GameManager.instance.PlayerDied();
    }
}