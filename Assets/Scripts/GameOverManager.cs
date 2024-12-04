using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;  // Thêm Instance tĩnh cho GameOverManager

    public GameObject gameOverPanel;   // Panel hiển thị Game Over
    public Text scoreText;             // Text hiển thị điểm số
    public Text highestScoreText;      // Text hiển thị highest score
    public Button restartButton;       // Button để chơi lại

    void Awake()
    {
        // Đảm bảo chỉ có một instance của GameOverManager
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
        restartButton.onClick.AddListener(RestartGame);
    }

    // Hiển thị Game Over panel và điểm số
    public void ShowGameOverPanel()
    {
        // Cập nhật điểm và highest score
        scoreText.text = "Your Score: " + ScoreManager.Instance.GetCurrentScore();
        highestScoreText.text = "Highest Score: " + ScoreManager.Instance.GetHighestScore();

        // Hiển thị Game Over Panel
        gameOverPanel.SetActive(true);
    }

    private void RestartGame()
    {
        // Load lại scene hiện tại
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
