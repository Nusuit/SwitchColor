using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;

    public TMP_Text scoreText;           // TMP_Text hiển thị điểm số
    public TMP_Text highestScoreText;    // TMP_Text hiển thị highest score
    public GameObject gameOverPanel;     // Panel hiển thị Game Over
    public GameObject MainMenuButtons;   // Các nút menu trong MainMenu (nếu cần)

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Giữ GameOverManager khi chuyển scene
            Debug.Log("GameOverManager Initialized");
        }
        else
        {
            Destroy(gameObject);  // Nếu đã có instance, hủy đi đối tượng này
            Debug.Log("GameOverManager already exists, destroying duplicate.");
        }
    }

    // Hiển thị Game Over panel và cập nhật điểm số
    public void ShowGameOverPanel()
    {
        if (ScoreManager.Instance != null)
        {
            // Lấy điểm từ ScoreManager
            int score = ScoreManager.Instance.GetCurrentScore();
            int highestScore = ScoreManager.Instance.GetHighestScore();

            // Cập nhật thông tin vào các TMP_Text
            scoreText.text = "Your Score: " + score.ToString();
            highestScoreText.text = "Highest Score: " + highestScore.ToString();

            // Hiển thị Game Over Panel
            gameOverPanel.SetActive(true);
            MainMenuButtons.SetActive(false);  // Ẩn các nút MainMenu khi game over
        }
        else
        {
            Debug.LogError("ScoreManager instance is missing in the scene!");
        }
    }
}
