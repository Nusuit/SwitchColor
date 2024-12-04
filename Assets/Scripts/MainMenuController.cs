using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Danh sách các màn chơi
    public string[] levels = { "GamePlay", "GamePlay1", "GamePlay2", "GamePlay3", "GamePlay4", "GamePlay5", "GamePlay6" };
    private int currentLevelIndex;

    public AudioClip mainMenuMusic;

    void Start()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayBackgroundMusic(mainMenuMusic);
        }
    }

    // Khi người chơi nhấn nút Play, chọn màn chơi ngẫu nhiên
    public void StartGame()
    {
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

    // Mở menu Settings
    public void OpenSettings()
    {
        Debug.Log("Settings menu opened.");
        // Chuyển sang màn Settings (tạo scene Settings sau này)
        SceneManager.LoadScene("Settings");
    }
}
