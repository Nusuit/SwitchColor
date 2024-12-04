using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class LanguageSettings : MonoBehaviour
{
    public TMP_Text[] textsToTranslate;

    private Dictionary<string, string[]> translations = new Dictionary<string, string[]>
    {
        {
            "English", new string[]
            {
                "Settings", "General", "Language", "Control", "Audio", "Play", "Quit"
            }
        },
        {
            "Vietnamese", new string[]
            {
                "Cài đặt", "Chung", "Ngôn ngữ", "Điều khiển", "Âm thanh", "Chơi", "Thoát"
            }
        }
    };

    public void SetLanguage(string language)
    {
        if (translations.ContainsKey(language))
        {
            string[] selectedTranslations = translations[language];

            for (int i = 0; i < textsToTranslate.Length; i++)
            {
                if (i < selectedTranslations.Length)
                {
                    textsToTranslate[i].text = selectedTranslations[i];
                }
            }

            Debug.Log("Language set to " + language);
        }
        else
        {
            Debug.LogError("Language not supported: " + language);
        }
    }

    public void SetEnglish()
    {
        SetLanguage("English");
    }

    public void SetVietnamese()
    {
        SetLanguage("Vietnamese");
    }
}
