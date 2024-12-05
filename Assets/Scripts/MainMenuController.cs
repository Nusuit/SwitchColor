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
        // Chạy nhạc nền của menu nếu có
        if (AudioManager.Instance != null && mainMenuMusic != null)
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
}
