using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highestScoreText;

    void Start()
    {
        if (ScoreManager.Instance == null)
        {
            Debug.LogError("ScoreManager instance is missing in the scene!");
            return;
        }

        UpdateUI();
    }

    // Cập nhật UI khi có sự thay đổi
    public void UpdateUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + ScoreManager.Instance.GetCurrentScore().ToString();
        if (highestScoreText != null) highestScoreText.text = "Highest Score: " + ScoreManager.Instance.GetHighestScore().ToString();
    }

    // Refresh UI mỗi khi có thay đổi
    public void RefreshUI()
    {
        UpdateUI();  // Cập nhật lại UI
    }
}
