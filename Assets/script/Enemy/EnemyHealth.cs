using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int experienceValue = 1;
    [Header("Health")]
    public int maxHealth = 3;

    private int currentHealth;
    private bool isDead;

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead || damage <= 0)
            return;

        currentHealth = Mathf.Max(currentHealth - damage, 0);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        GameManager.instance.AddScore(100);
        GameManager.instance.AddExperience(experienceValue);
        Destroy(gameObject);
    }
}