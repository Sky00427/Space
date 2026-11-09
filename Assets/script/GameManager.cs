using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;
    [Header("Score")]
    public int currentScore = 0;

    public int WinScore;

    public string winSceneName;
    public string loseSceneName;
    public TMP_Text scoreText;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int value)
    {
        currentScore += value;
        UpdateScoreUI();
        if (currentScore >= WinScore)
        {
            End(true);
        }
    }

    public void AddExperience(int value)
    {
        if (player.TryGetComponent(out PlayerLevel playerLevel))
        {
            playerLevel.AddExperience(value);
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score : " + currentScore;
    }

    public void PlayerDied()
    {
        End(false);
    }

    void End(bool isWin)
    {
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
