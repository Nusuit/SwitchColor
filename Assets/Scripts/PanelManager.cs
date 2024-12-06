using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject controlPanel;
    public GameObject audioPanel;

    public void OpenControlPanel()
    {
        controlPanel.SetActive(true);
        audioPanel.SetActive(false);
    }

    public void OpenAudioPanel()
    {
        controlPanel.SetActive(false);
        audioPanel.SetActive(true);
    }
}
