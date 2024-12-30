using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Danh sách các màn chơi
    public string[] levels = { "GamePlay", "GamePlay1", "GamePlay2", "GamePlay3", "GamePlay4", "GamePlay5", "GamePlay6" };
    private int currentLevelIndex;
    public AudioClip mainMenuMusic;
    public GameObject mainMenuButtons; // Thêm reference đến MainMenuButtons

    void Start()
    {
        // Chạy nhạc nền của menu nếu có
        if (AudioManager.Instance != null && mainMenuMusic != null)
        {
            AudioManager.Instance.PlayBackgroundMusic(mainMenuMusic);
        }

        // Show MainMenuButtons khi vào menu
        if (mainMenuButtons != null)
        {
            mainMenuButtons.SetActive(true);
        }
    }

    // Khi người chơi nhấn nút Play, chọn màn chơi ngẫu nhiên
    public void StartGame()
    {
        // Ẩn MainMenuButtons trước khi load scene mới
        if (mainMenuButtons != null)
        {
            mainMenuButtons.SetActive(false);
        }

        // Reset điểm về 0 khi bắt đầu game mới
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.ResetScore();
        }

        LoadRandomLevel();
    }

    // Hàm random màn chơi
    void LoadRandomLevel()
    {
        // Chọn một màn chơi ngẫu nhiên từ danh sách
        int randomIndex = Random.Range(0, levels.Length);
        while (randomIndex == currentLevelIndex)
        {
            randomIndex = Random.Range(0, levels.Length);
        }
        currentLevelIndex = randomIndex;

        // Tải màn chơi ngẫu nhiên
        SceneManager.LoadScene(levels[currentLevelIndex]);
    }

    // Thêm method để hiện MainMenuButtons khi cần
    public void ShowMainMenu()
    {
        if (mainMenuButtons != null)
        {
            mainMenuButtons.SetActive(true);
        }
    }
}