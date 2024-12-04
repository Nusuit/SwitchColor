using UnityEngine;
using UnityEngine.UI;

public class BaseManager : MonoBehaviour
{
    public GameObject panel;
    public Text scoreText;
    public Button continueButton;

    protected int currentScore;

    public int CurrentScore => currentScore;

    public virtual void ShowPanel(int score)
    {
        currentScore = score;
        scoreText.text = "Score: " + currentScore;
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
