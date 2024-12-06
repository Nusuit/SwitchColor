using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;
    public TMP_Text scoreText;
    public TMP_Text highestScoreText;
    public GameObject GameOverPanel; // Biến GameObject cho GameOverPanel
    public GameObject MainMenuButtons;
    public GameObject GameOverSingleton;
    public GameObject ScoreSingleton;

    private GameObject GameOverPanelInstance; // Biến GameObject để lưu bản sao của GameOverPanel

    void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject); // Đảm bảo GameObject này không bị xóa khi chuyển scene
            Debug.Log("GameOverManager Initialized");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("GameOverManager already exists, destroying duplicate.");
        }
    }

    void Start()
    {
        // Kiểm tra xem GameOverPanel đã được kéo vào trong Inspector chưa
        if (GameOverPanel == null)
        {
            Debug.LogError("GameOverPanel is not assigned in the Inspector!");
            return;
        }

        // Tạo bản sao của GameOverPanel từ Inspector
        GameOverPanelInstance = Instantiate(GameOverPanel);
        GameOverPanelInstance.transform.SetParent(null); // Đảm bảo GameOverPanel là root object

        // Đổi tên bản sao
        GameOverPanelInstance.name = "GameOverPanel"; // Đổi tên nếu bạn không muốn hậu tố "(Clone)"

        // Đảm bảo GameOverPanel không bị xóa khi chuyển scene
        DontDestroyOnLoad(GameOverPanelInstance);

        GameOverPanelInstance.SetActive(false); // Ẩn panel khi bắt đầu
    }


    public void ShowGameOverPanel()
    {
        Debug.Log("ShowGameOverPanel called");

        if (Instance == null)
        {
            Debug.LogError("GameOverManager Instance is null!");
            return;
        }

        if (ScoreManager.Instance == null)
        {
            Debug.LogError("ScoreManager Instance is null!");
            return;
        }

        // Cập nhật điểm số
        int score = ScoreManager.Instance.GetCurrentScore();
        int highestScore = ScoreManager.Instance.GetHighestScore();

        if (scoreText != null) scoreText.text = "Your Score: " + score.ToString();
        if (highestScoreText != null) highestScoreText.text = "Highest Score: " + highestScore.ToString();

        if (GameOverPanelInstance != null)
        {
            GameOverPanelInstance.SetActive(true); // Hiện GameOverPanel
            Debug.Log("GameOverPanel: " + GameOverPanelInstance);

            Debug.Log("GameOverPanel has been opened");

            // Ẩn các UI liên quan khi cần thiết
            if (GameOverSingleton != null && GameOverSingleton.activeSelf)
                GameOverSingleton.SetActive(false);

            if (ScoreSingleton != null && ScoreSingleton.activeSelf)
                ScoreSingleton.SetActive(false);

            // Đảm bảo GameOverSingleton được kích hoạt trước khi gọi coroutine
            if (GameOverSingleton != null && !GameOverSingleton.activeSelf)
                GameOverSingleton.SetActive(true);

            // Bắt đầu coroutine để chuyển cảnh sau một khoảng thời gian
            StartCoroutine(LoadMainMenuAfterDelay(0.5f)); // Điều chỉnh độ trễ nếu cần
        }
        else
        {
            Debug.LogError("GameOverPanel is missing or has been destroyed!");
        }
    }

    // Coroutine để chuyển cảnh sau một khoảng thời gian
    private IEnumerator LoadMainMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MainMenu");
    }
}
