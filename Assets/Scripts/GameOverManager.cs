using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance { get; private set; }
    public GameObject gameOverPanel;
    public GameObject mainMenuButtons;
    public TMP_Text scoreText;
    public TMP_Text highestScoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Ẩn GameOverPanel khi bắt đầu
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void ShowGameOverPanel()
    {
        Debug.Log("ShowGameOverPanel called");

        // Load về MainMenu scene
        SceneManager.LoadScene("MainMenu");

        // Đăng ký event để thực hiện sau khi scene đã load xong
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            // Tìm lại MainMenuButtons trong scene mới
            mainMenuButtons = GameObject.Find("MainMenuButtons");
            if (mainMenuButtons != null)
            {
                mainMenuButtons.SetActive(false);
                Debug.Log("MainMenuButtons deactivated");
            }

            // Hiện GameOverPanel
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
                Debug.Log("GameOverPanel activated");
                UpdateUI();
            }
        }

        // Hủy đăng ký event sau khi đã xử lý
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void RestartGame()
    {
        Debug.Log("RestartGame called");

        // Ẩn GameOverPanel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        // Reset điểm
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.ResetScore();
        }

        // Load game mới
        MainMenuController menuController = FindFirstObjectByType<MainMenuController>();
        if (menuController != null)
        {
            menuController.StartGame();
        }
    }

    public void ReturnToMainMenu()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        // Tìm và hiện MainMenuButtons
        mainMenuButtons = GameObject.Find("MainMenuButtons");
        if (mainMenuButtons != null)
        {
            mainMenuButtons.SetActive(true);
        }

        // Reset điểm
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.ResetScore();
        }
    }

    private void UpdateUI()
    {
        if (ScoreManager.Instance == null) return;

        if (scoreText != null)
        {
            scoreText.text = "Score: " + ScoreManager.Instance.GetCurrentScore();
        }

        if (highestScoreText != null)
        {
            highestScoreText.text = "Highest Score: " + ScoreManager.Instance.GetHighestScore();
        }
    }
}