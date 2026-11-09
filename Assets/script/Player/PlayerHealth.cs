using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 3;

    [SerializeField]
    private int currentHealth;

    [SerializeField] private int invincibleDuration;
    [SerializeField] private bool isInvincible = false;


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
        if (isDead || damage <= 0 || isInvincible) return;

        currentHealth = Mathf.Max(currentHealth - damage, 0);
        StartCoroutine(InvincibleTimer(invincibleDuration));

        Debug.Log($"Player Health: {currentHealth}/{maxHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
        OnHealthChanged.Invoke();
    }
    IEnumerator InvincibleTimer(int duration)
    {
        isInvincible = true;
        yield return new WaitForSeconds(duration);
        isInvincible = false;
    }

    void Die()
    {
        isDead = true;
        GameManager.instance.PlayerDied();
    }
}