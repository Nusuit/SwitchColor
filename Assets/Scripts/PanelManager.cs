using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject generalPanel;
    public GameObject languagePanel;
    public GameObject controlPanel;
    public GameObject audioPanel;

    public void OpenGeneralPanel()
    {
        generalPanel.SetActive(true);
        languagePanel.SetActive(false);
        controlPanel.SetActive(false);
        audioPanel.SetActive(false);
    }

    public void OpenLanguagePanel()
    {
        generalPanel.SetActive(false);
        languagePanel.SetActive(true);
        controlPanel.SetActive(false);
        audioPanel.SetActive(false);
    }
    public void OpenControlPanel()
    {
        generalPanel.SetActive(false);
        languagePanel.SetActive(false);
        controlPanel.SetActive(true);
        audioPanel.SetActive(false);
    }

    public void OpenAudioPanel()
    {
        generalPanel.SetActive(false);
        languagePanel.SetActive(false);
        controlPanel.SetActive(false);
        audioPanel.SetActive(true);
    }
}
