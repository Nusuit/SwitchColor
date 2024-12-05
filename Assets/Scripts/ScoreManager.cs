using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TMP_Text scoreText;  // Hiển thị điểm số
    public TMP_Text highestScoreText;  // Hiển thị điểm cao nhất
    public int currentScore = 0;
    public int highestScore = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Giữ ScoreManager khi chuyển scene
        }
        else
        {
            Destroy(gameObject);  // Nếu đã có instance, phá hủy đối tượng này
        }
    }

    // Cập nhật điểm số và UI
    public void AddPoints(int points)
    {
        currentScore += points;

        if (currentScore > highestScore)
        {
            highestScore = currentScore;
        }

        UpdateUI();  // Cập nhật giao diện
    }

    // Cập nhật UI với điểm số và điểm cao nhất
    private void UpdateUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + currentScore;
        if (highestScoreText != null) highestScoreText.text = "Highest Score: " + highestScore;
    }

    // Getter methods
    public int GetCurrentScore() => currentScore;
    public int GetHighestScore() => highestScore;
}
