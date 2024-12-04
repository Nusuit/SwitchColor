using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;  // Singleton instance

    public Text scoreText;  // UI Text để hiển thị điểm số
    public Text moneyText;  // UI Text để hiển thị tiền
    public int currentScore = 0;
    public int currentMoney = 0;
    public int highestScore = 0;  // Điểm số cao nhất

    void Awake()
    {
        // Đảm bảo chỉ có một instance của ScoreManager
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
        LoadScores();  // Load điểm số và tiền từ PlayerPrefs
        UpdateUI();
    }

    // Thêm điểm vào Score và Money
    public void AddPoints(int points)
    {
        currentScore += points;  // Thêm điểm vào Score
        currentMoney += points / 2;  // Chia điểm cho Money

        if (currentScore > highestScore)
        {
            highestScore = currentScore;  // Cập nhật điểm cao nhất
        }

        UpdateUI();
        SaveScores();  // Lưu lại điểm số và tiền
    }

    // Cập nhật UI với điểm số và tiền
    void UpdateUI()
    {
        scoreText.text = "Score: " + currentScore;
        moneyText.text = "Money: " + currentMoney;
    }

    // Lưu điểm và tiền vào PlayerPrefs
    void SaveScores()
    {
        PlayerPrefs.SetInt("CurrentScore", currentScore);
        PlayerPrefs.SetInt("CurrentMoney", currentMoney);
        PlayerPrefs.SetInt("HighestScore", highestScore);
        PlayerPrefs.Save();
    }

    // Tải điểm và tiền từ PlayerPrefs
    void LoadScores()
    {
        currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        currentMoney = PlayerPrefs.GetInt("CurrentMoney", 0);
        highestScore = PlayerPrefs.GetInt("HighestScore", 0);
    }

    // Lấy điểm số hiện tại
    public int GetCurrentScore()
    {
        return currentScore;
    }

    // Lấy điểm số cao nhất
    public int GetHighestScore()
    {
        return highestScore;
    }
}
