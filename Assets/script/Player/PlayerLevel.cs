using System;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int maxLevel = 10;
    [SerializeField] private int currentExperience = 0;

    public int MaxExperienceMultiplier => currentLevel * 4;

    public int CurrentLevel => currentLevel;
    public int CurrentExperience => currentExperience;

    public Action OnLevelChanged;
    public Action OnExperienceChanged;

    void Start()
    {
        ResetLevel();
    }

    public void ResetLevel()
    {
        currentLevel = 1;
        currentExperience = 0;
        OnLevelChanged?.Invoke();
        OnExperienceChanged?.Invoke();
    }

    public void LevelUp()
    {
        if (currentLevel < maxLevel)
        {
            currentLevel++;
            currentExperience = 0;
            OnExperienceChanged?.Invoke();
            OnLevelChanged?.Invoke();
        }
    }

    public void AddExperience(int experience)
    {
        if (currentLevel >= maxLevel) return;

        currentExperience += experience;

        int experienceToNextLevel = MaxExperienceMultiplier;

        if (currentExperience >= experienceToNextLevel)
        {
            LevelUp();
        }
        OnExperienceChanged?.Invoke();

    }
}