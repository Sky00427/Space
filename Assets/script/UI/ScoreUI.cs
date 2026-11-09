using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    void OnEnable()
    {
        gameManager.OnScoreChanged += UpdateScore;
    }

    void Start()
    {
        UpdateScore(gameManager.CurrentScore);
    }

    void OnDisable()
    {
        gameManager.OnScoreChanged -= UpdateScore;
    }

    void UpdateScore(int score)
    {
        scoreText.text = $"Score : {score}";
    }
}