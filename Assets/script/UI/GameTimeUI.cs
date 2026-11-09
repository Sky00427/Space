using TMPro;
using UnityEngine;

public class GameTimeUI : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private TextMeshProUGUI timeText;

    private int lastDisplayedSeconds = -1;

    void Update()
    {
        int totalSeconds = Mathf.CeilToInt(gameManager.RemainingTime);

        if (totalSeconds == lastDisplayedSeconds) return;

        lastDisplayedSeconds = totalSeconds;

        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        timeText.text = $"{minutes:00}:{seconds:00}";
    }
}