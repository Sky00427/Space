using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;

    [SerializeField] Image healthBar;
    [SerializeField] TextMeshProUGUI healthText;

    void Start()
    {
        playerHealth.OnHealthChanged += UpdateHealth;
    }

    void OnDisable()
    {
        playerHealth.OnHealthChanged -= UpdateHealth;
    }

    void UpdateHealth()
    {
        healthBar.fillAmount = (float)playerHealth.CurrentHealth / playerHealth.MaxHealth;
        healthText.text = $"{playerHealth.CurrentHealth}/{playerHealth.MaxHealth}";
    }
}