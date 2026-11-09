using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLevelUI : MonoBehaviour
{
    [SerializeField] private PlayerLevel playerLevel;

    [SerializeField] Image experienceBar;
    [SerializeField] TextMeshProUGUI levelText;

    void Start()
    {
        playerLevel.OnExperienceChanged += UpdateExperience;
        playerLevel.OnLevelChanged += UpdateLevel;
    }

    void OnDisable()
    {
        playerLevel.OnExperienceChanged -= UpdateExperience;
        playerLevel.OnLevelChanged -= UpdateLevel;
    }

    void UpdateLevel()
    {
        levelText.text = $"Level: {playerLevel.CurrentLevel}";
    }

    void UpdateExperience()
    {
        experienceBar.fillAmount = (float)playerLevel.CurrentExperience / playerLevel.MaxExperienceMultiplier;
    }
}

