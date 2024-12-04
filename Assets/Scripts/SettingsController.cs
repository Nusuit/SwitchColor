using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject MainMenuButtons;

    public void OpenSettings()
    {
        SettingsPanel.SetActive(true);
        MainMenuButtons.SetActive(false);
    }

    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
        MainMenuButtons.SetActive(true);
    }
}
