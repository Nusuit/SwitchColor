using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : BaseManager
{
    public Button restartButton;         // Button để chơi lại

    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    // Hiển thị Game Over panel và điểm số
    public override void ShowPanel(int score)
    {
        base.ShowPanel(score);
    }

    // Hàm để chơi lại game (reset lại mọi thứ và bắt đầu lại)
    private void RestartGame()
    {
        // Load lại scene hiện tại
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
