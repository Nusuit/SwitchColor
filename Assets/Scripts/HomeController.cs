using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeController : MonoBehaviour
{
    // Khi người chơi nhấn nút Play, bắt đầu trò chơi
    public void StartGame()
    {
        // Chuyển sang màn chơi
        SceneManager.LoadScene("GamePlay");
    }

    // Mở cửa hàng
    public void OpenShop()
    {
        // Chuyển sang màn cửa hàng
        SceneManager.LoadScene("Shop");
    }

    // Quay lại trang chính (Main Menu)
    public void GoToMainMenu()
    {
        // Chuyển về màn chính
        SceneManager.LoadScene("MainMenu");
    }
}
