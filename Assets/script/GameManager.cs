using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;

    [Header("Game Time")]
    [SerializeField, Min(1f)]
    private float gameDuration = 60f;

    [SerializeField]
    private float remainingTime;

    private bool isGameEnded;

    public float GameDuration => gameDuration;
    public float RemainingTime => remainingTime;

    [Header("Score")]
    public int currentScore = 0;

    public int CurrentScore => currentScore;

    public event Action<int> OnScoreChanged;

    public string winSceneName;
    public string loseSceneName;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        remainingTime = gameDuration;
    }

    void Update()
    {
        if (isGameEnded)
            return;

        remainingTime = Mathf.Max(remainingTime - Time.deltaTime, 0f);

        if (remainingTime <= 0f)
        {
            TimeUp();
        }
    }

    void TimeUp()
    {
        End(true);
    }

    public void AddScore(int value)
    {
        currentScore += value;
        OnScoreChanged?.Invoke(currentScore);
    }

    public void AddExperience(int value)
    {
        if (player.TryGetComponent(out PlayerLevel playerLevel))
        {
            playerLevel.AddExperience(value);
        }
    }

    

    public void PlayerDied()
    {
        End(false);
    }

    void End(bool isWin)
    {
        if (isGameEnded) return;

        isGameEnded = true;

        if (isWin)
        {
            SceneManager.LoadScene(winSceneName);
        }
        else
        {
            SceneManager.LoadScene(loseSceneName);
        }
    }
}
