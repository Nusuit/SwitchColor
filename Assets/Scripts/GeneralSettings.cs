using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GeneralSettings : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullScreenToggle;
    public Slider brightnessSlider;

    private Resolution[] resolutions;

    void Start()
    {
        // Load available screen resolutions
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(option));

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Load saved settings or set default
        fullScreenToggle.isOn = Screen.fullScreen;
        brightnessSlider.value = PlayerPrefs.GetFloat("Brightness", 1.0f);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        Debug.Log("Resolution set to: " + resolution.width + " x " + resolution.height);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        Debug.Log("Fullscreen mode: " + isFullScreen);
    }

    public void SetBrightness(float brightness)
    {
        // Placeholder logic for setting brightness
        Debug.Log("Brightness set to: " + brightness);
        PlayerPrefs.SetFloat("Brightness", brightness);
    }
}
