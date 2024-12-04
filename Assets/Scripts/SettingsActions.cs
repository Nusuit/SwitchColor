using UnityEngine;
using UnityEngine.UI;

public class SettingsActions : MonoBehaviour
{
    public GameObject generalSettingsPanel;
    public GameObject languageSettingsPanel;
    public GameObject controlSettingsPanel;
    public GameObject audioSettingsPanel;

    public Toggle englishToggle;
    public Toggle vietnameseToggle;
    public Toggle spaceControlToggle;
    public Toggle enterControlToggle;
    public Slider musicSlider;
    public Slider soundEffectSlider;

    private LanguageSettings languageSettings; // Thêm tham chiếu đến LanguageSettings

    void Start()
    {
        languageSettings = Object.FindFirstObjectByType<LanguageSettings>();
        if (languageSettings == null)
        {
            Debug.LogError("LanguageSettings instance not found in the scene.");
        }
    }

    public void OnGeneralButtonClicked()
    {
        Debug.Log("General button clicked");
        ShowPanel(generalSettingsPanel);
    }

    public void OnLanguageButtonClicked()
    {
        ShowPanel(languageSettingsPanel);
        englishToggle.onValueChanged.AddListener(delegate { languageSettings.SetEnglish(); });
        vietnameseToggle.onValueChanged.AddListener(delegate { languageSettings.SetVietnamese(); });
    }

    public void OnControlButtonClicked()
    {
        Debug.Log("Control button clicked");
        ShowPanel(controlSettingsPanel);
        spaceControlToggle.onValueChanged.AddListener(delegate { SetControl("Space"); });
        enterControlToggle.onValueChanged.AddListener(delegate { SetControl("Enter"); });
    }

    public void OnAudioButtonClicked()
    {
        Debug.Log("Audio button clicked");
        ShowPanel(audioSettingsPanel);
        musicSlider.onValueChanged.AddListener(delegate { AdjustMusicVolume(musicSlider.value); });
        soundEffectSlider.onValueChanged.AddListener(delegate { AdjustSoundEffectVolume(soundEffectSlider.value); });
    }

    private void ShowPanel(GameObject panel)
    {
        if (generalSettingsPanel != null) generalSettingsPanel.SetActive(false);
        if (languageSettingsPanel != null) languageSettingsPanel.SetActive(false);
        if (controlSettingsPanel != null) controlSettingsPanel.SetActive(false);
        if (audioSettingsPanel != null) audioSettingsPanel.SetActive(false);

        if (panel != null) panel.SetActive(true);
    }

    private void SetControl(string controlType)
    {
        Debug.Log("Control set to: " + controlType);
    }

    private void AdjustMusicVolume(float volume)
    {
        Debug.Log("Music volume set to: " + volume);
    }

    private void AdjustSoundEffectVolume(float volume)
    {
        Debug.Log("Sound effect volume set to: " + volume);
    }
}
