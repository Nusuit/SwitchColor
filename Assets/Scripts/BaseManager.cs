using UnityEngine;
using UnityEngine.UI;

public class BaseManager : MonoBehaviour
{
    public GameObject panel;            // Panel chung (Game Over hoặc Reward)
    public Text scoreText;              // Text hiển thị điểm số (sẽ kế thừa từ các script con)
    public Button continueButton;       // Button tiếp tục (sẽ kế thừa từ các script con)

    protected int currentScore;         // Điểm số hiện tại (có thể sử dụng trong các script con)

    // Hiển thị panel và cập nhật điểm số
    public virtual void ShowPanel(int score)
    {
        currentScore = score;
        scoreText.text = "Score: " + currentScore;
        panel.SetActive(true);
    }

    // Hàm để đóng panel
    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
