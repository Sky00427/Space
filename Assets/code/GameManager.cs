using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Life")]
    public int lives = 3;

    // 三個生命圖示
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
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
        UpdateLivesUI();
        UpdateScoreUI();
    }

    public void AddScore(int value)
    {
        currentScore += value;
        UpdateScoreUI();
        if(currentScore >= WinScore)
        {
            End(true);
        }
    }

    public void LoseLife()
    {
        lives--;

        UpdateLivesUI();

        if (lives <= 0)
        {
            End(false);
        }
    }

    void UpdateLivesUI()
    {
        life1.SetActive(lives >= 1);
        life2.SetActive(lives >= 2);
        life3.SetActive(lives >= 3);
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score : " + currentScore;
    }

    void End(bool isWin)
    {
        if(isWin)
        {
            SceneManager.LoadScene(winSceneName);
        }
        else
        {
            SceneManager.LoadScene(loseSceneName);
        }
    }
}
