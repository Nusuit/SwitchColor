using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : BaseManager
{
    public static ScoreManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Nếu có điểm đã lưu, bạn có thể tải lại ở đây nếu muốn.
        currentScore = 0;
        UpdateScoreText();
    }

    // Thêm điểm vào hiện tại
    public void AddPoints(int points)
    {
        currentScore += points;
        UpdateScoreText();
    }

    // Cập nhật UI với điểm số hiện tại
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScore;
    }
}
